using Godot;
using System;

public partial class Stanek : Area2D
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
			var dialogManager = Engine.GetSingleton("DialogManager") as DialogManager;

			if (!Inventory.HasItem("GalacticTea"))
			{
				dialogManager?.ShowDialog("Hledáš něco, že by kartu?");
				dialogManager?.ShowDialog("Možná mám co hledáš, ale nebude to zadarmo.");
				dialogManager?.ShowDialog("Žížním po čaji, přines mi ho a já ti dám po čem žádáš.");
			
			}
			else if (!Inventory.HasItem("Card"))
			{
				dialogManager?.ShowDialog("Děkuji, zde máš to co jsi hledal.");
				Inventory.RemoveItem("GalacticTea");
				Inventory.AddItem("Card");}
			else
			{
				dialogManager?.ShowDialog("Už mám co chci, zmizni.");
			}

		}
	}
}
