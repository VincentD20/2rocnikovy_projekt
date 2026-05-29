using Godot;
using System;

public partial class Mechanik : Area2D
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
			if(Inventory.HasItem("Lubricant"))
			{
				dialogManager?.ShowDialogSequence( new string[] {
					"Mazivo? To je ono!",
					"Čekal jsem na to celej den.",
					"Tady máš ten náhradní díl co jsi potřeboval.",
					"A teď zmiz, mám práci."
				});
				Inventory.RemoveItem("Lubricant");
				Inventory.AddItem("SparePart");
				return;
			} 
			else if (Inventory.HasItem("SparePart"))
			{
				dialogManager?.ShowDialog("Už jsem ti dal co jsi chtěl. Zmiz.");
				return;
			} 
			else 
			{
				dialogManager?.ShowDialogSequence( new string[] {
					"Hele, nemám čas na řeči.",
					"Tyhle motory se samy neopraví.",
					"Jestli chceš pomoct, přines mi mazivo z Kryogenické komory.",
					"Bez toho se tu nehni."
				});
			}
		}
	}
}
