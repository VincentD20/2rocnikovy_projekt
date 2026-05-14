using Godot;
using System;

public partial class Pocitac : Area2D
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
				"PŘÍSTUP POVOLEN. Vítej, kapitáne Vendo.",
				"Databáze černých děr — poslední záznam:",
				"Černá díra č.42 se odpojila od sítě.",
				"Důvod: Dovolená.",
				"Poznámka: Černé díry nemají dovolené.",
				"Druhá poznámka: Tato černá díra si to nemyslí."
			});
		}
	}
}
