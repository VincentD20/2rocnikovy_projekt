using Godot;
using System;

public partial class Satelit : Area2D
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
			dialogManager?.ShowDialogSequence( new string[] {
				"ZÁZNAM #4471 — SATELIT-9",
				"Objekt č.42 mění kurz.",
				"Nová trajektorie: Sektor 7, Vesmírná pláň.",
				"Varování: Objekt se pohybuje... dobrovolně.",
				"Konec záznamu."
			});

		}
	}
}
