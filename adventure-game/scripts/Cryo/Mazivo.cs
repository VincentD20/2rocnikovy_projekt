using Godot;
using System;

public partial class Mazivo : Area2D
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
			if (!Inventory.HasItem("Lubricant"))
			{
				Inventory.AddItem("Lubricant");
				dialogManager?.ShowDialog("Našel jsi mazivo. Bude se hodit.");
			}
			else
			{
				dialogManager?.ShowDialog("Mazivo už máš.");
			}
		}
	}
}
