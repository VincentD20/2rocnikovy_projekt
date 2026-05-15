using Godot;
using System;

public partial class FialDvere : Area2D
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
			if(Inventory.HasItem("Card"))
			{
				GetTree().ChangeSceneToFile("res://scenes/VyskumnaLod.tscn");
				return;
			}
			dialogManager?.ShowDialog("Dveře jsou zamčené. Potřebuješ kartu.");

		}
	}
}
