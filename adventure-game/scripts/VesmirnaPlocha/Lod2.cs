using Godot;
using System;

public partial class Lod2 : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
			var dialogManager = GetNode<DialogManager>("/root/DialogManager");
			
			if (Inventory.HasItem("Vstup"))
			{
				dialogManager?.ShowDialog("Dr. Vesmírník: Už víš co dělat. Jdi dál.");
				return;
			}
			
			if (!Inventory.HasItem("HolographicRecording"))
			{
				dialogManager?.ShowDialog("Dr. Vesmírník: Nemám důvod tě pustit. Přines důkaz.");
				return;
			}
			
			dialogManager?.ShowDialogSequenceWithCallback(new string[]
			{
				"Dr. Vesmírník: Aha. Detektiv. Výborně.",
				"Dr. Vesmírník: Takže... přišel jsi kvůli č.42.",
				"Dr. Vesmírník: Nepřesunul jsem ji. Ona odešla sama.",
				"Dr. Vesmírník: Byl jsem přítomen. Prostě se zvedla a odešla.",
				"Dr. Vesmírník: Říkal jsem jí, že to není dobrý nápad.",
				"Dr. Vesmírník: Ona řekla: 'Mně je to jedno, jsem černá díra.'",
				"Dr. Vesmírník: Těžko se s tím hádá.",
				"Dr. Vesmírník: Každopádně — máš ten záznam?",
				"Dr. Vesmírník: Dobře. Vstup povolen. Ale neříkej jí, že jsem tě pustil.",
				"Dr. Vesmírník: Ona si pamatuje."
			}, () => Inventory.AddItem("Vstup"));
		}
	}
}
