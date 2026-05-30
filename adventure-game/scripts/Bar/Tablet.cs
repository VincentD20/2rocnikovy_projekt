using Godot;
using System;

public partial class Tablet : Area2D
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
			dialogManager?.ShowDialogSequence(new string[]
			{
				"SYSTÉM ASTEROID BARU v2.3",
				"Dnešní nabídka: Galaktický čaj, Marsové pivo, Temná hmota (vyprodáno).",
				"Poznámka pro personál: Přestaňte krmit černé díry. Jsou na dietě."
			});
		}
	}
}
