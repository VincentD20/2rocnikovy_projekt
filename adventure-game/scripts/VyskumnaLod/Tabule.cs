using Godot;
using System;

public partial class Tabule : Area2D
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
			GameState.RegisterClick("Tabule");
			int clicks = GameState.GetClickCount("Tabule");
			if (clicks == 1)
			{
				dialogManager?.ShowDialogSequence(new string[]
				{
					"Poznámky: Černá díra č.42 opustila orbitální dráhu.",
					"Poslední poloha: Sektor 7, Vesmírná pláň.",
					"Teorie: Objekt vykazuje známky vědomého pohybu.",
					"Varování: Nepřibližovat se bez povolení."
				});
			}
			else
			{
				dialogManager?.ShowDialog("Na tabuli není nic nového.");
			}
		}
	}
}
