using Godot;
using System;

public partial class Navigace1 : Area2D
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
				"Holografická mapa zobrazuje galaxii.",
				"Oblast Sektoru 7 je označena červeně.",
				"Poznámka systému: Objekt č.42 byl poslední zaznamenaný v této oblasti.",
				"Další data nejsou k dispozici."
			});

		}
	}
}
