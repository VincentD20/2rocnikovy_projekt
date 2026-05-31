using Godot;
using System;

public partial class CernaDira : Area2D
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
			GameState.RegisterClick("CernaDira");
			int clicks = GameState.GetClickCount("CernaDira");
			if (!Inventory.HasItem("Vstup"))
			{
				dialogManager?.ShowDialog("Napřed si promluv s doktorem.");
				return;
			}
			if (clicks == 1)
			{
				dialogManager?.ShowDialogSequence(new string[]
				{
					"Opravdu chceš jít do černé díry?",
					"Už se nikdy nevrátíš",
					"Klikni pokud, chceš vstoupit do černé díry:"
				});
			} else
			{
				GetTree().ChangeSceneToFile("res://scenes/CernaDira.tscn");
			}
		}
	}
}
