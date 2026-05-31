using Godot;
using System;

public partial class KonecDira : Area2D
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
			dialogManager.ShowDialogSequenceWithCallback(new string[]
			{
				"Černá díra č.42: Díky za návštěvu.",
				"Černá díra č.42: Bylo tu trochu nuda.",
				"Černá díra č.42: Nevracím se.",
				"Černá díra č.42: Ale ty ano.",
				"*konec*"
			}, () => GetTree().ChangeSceneToFile("res://scenes/Konec.tscn"));
		}
	}
}
