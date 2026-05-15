using Godot;
using System;

public partial class Automat : Area2D
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
			if (!Inventory.HasItem("Coin"))
			{
				Inventory.AddItem("Coin");
				dialogManager?.ShowDialog("Našel jsi minci. (Bude se hodit)");
			}
			else
			{
				dialogManager?.ShowDialog("Automat je prázdný.");
			}



		}

	}
}
