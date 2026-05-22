using Godot;
public partial class SaveManager : Node
{
    private const string SavePath = "user://save.json";

    public override void _Ready()
    {
        GetTree().NodeRemoved += (node) => {
            if(node.SceneFilePath != "" && (node) != this) {
                SaveGame();
            }
        };
    }

    public void SaveGame()
    {
        // vytvoří prázdné Godot pole pro uložení předmětů z inventáře
        var inventoryArray = new Godot.Collections.Array();
        // projde každý předmět v inventáři a přidá ho do pole
        foreach (var item in Inventory.Items)
            inventoryArray.Add(item);

        // vytvoří prázdný Godot slovník pro uložení počtu kliknutí na objekty
        var clickCountsDict = new Godot.Collections.Dictionary();
        // projde každý záznam v GameState a zkopíruje ho do Godot slovníku
        foreach (var kvp in GameState.ObjectClickCounts)
            clickCountsDict[kvp.Key] = kvp.Value;

        // sestaví finální slovník s uloženými daty — tři položky
        var saveData = new Godot.Collections.Dictionary
        {
            { "inventory", inventoryArray },        // seznam předmětů které hráč nese
            { "clickCounts", clickCountsDict },     // které objekty byly použity
            { "scene", GetTree().CurrentScene.SceneFilePath } // cesta k aktuální scéně
        };

        // otevře soubor pro zápis (vytvoří ho pokud neexistuje)
        using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Write);
        // převede slovník na JSON řetězec a zapíše ho do souboru
        file.StoreString(Json.Stringify(saveData));
    }

    public void LoadGame()
    {
        // zastaví načítání pokud soubor s uloženou hrou neexistuje
        if (!FileAccess.FileExists(SavePath)) return;

        // otevře soubor pro čtení
        using var file = FileAccess.Open(SavePath, FileAccess.ModeFlags.Read);
        // přečte celý obsah souboru jako řetězec
        string jsonText = file.GetAsText();
        // parsuje JSON řetězec zpět do Godot slovníku
        var parsed = Json.ParseString(jsonText).AsGodotDictionary();

        // vymaže aktuální inventář před obnovením
        Inventory.Items.Clear();
        // projde uložené pole inventáře a přidá každý předmět zpět
        foreach (string item in parsed["inventory"].AsGodotArray())
            Inventory.Items.Add(item);

        // vymaže aktuální počty kliknutí před obnovením
        GameState.ObjectClickCounts.Clear();
        // projde uložené počty kliknutí a obnoví každý záznam
        foreach (var kvp in parsed["clickCounts"].AsGodotDictionary())
            GameState.ObjectClickCounts[kvp.Key.ToString()] = kvp.Value.AsInt32();

        // přepne na scénu ve které byl hráč při ukládání
        GetTree().ChangeSceneToFile(parsed["scene"].ToString());
    }
}