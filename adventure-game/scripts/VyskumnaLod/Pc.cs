using Godot;
using System;

public partial class Pc : Area2D
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
			GameState.RegisterClick("Pc");
			int clicks = GameState.GetClickCount("Pc");
			if (clicks == 1)
			{
				dialogManager?.ShowDialogSequence(new string[]
				{
					"EXPERIMENT #42 — STAV: NEDOKONČENO",
					"Hypotéza: Černá díra č.42 se přesunula dobrovolně.",
					"Přístupový kód pro Vesmírnou pláň: VK-42-FREEDOM"
				});
				Inventory.AddItem("VK-42-FREEDOM");
			}
			else
			{
				dialogManager?.ShowDialog("Data byla stažena.");
			}
		}
	}
}
