using Godot;
using System;

public partial class Robot : Area2D
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
			dialogManager?.ShowDialogSequence(new string[]
			{
				"Č.7 se také jednou začal ptát na nesprávné věci.",
				"Teď je součástí pohonné jednotky č.3.",
				"Hezky hoří.",
			});
		}
	}
}
