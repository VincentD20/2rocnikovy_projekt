using Godot;
using System;

public partial class AlienDvere : Area2D
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
			GameState.RegisterClick("AlienDvere");
			int clicks = GameState.GetClickCount("AlienDvere"); 
			if (clicks == 1)
			{
				dialogManager?.ShowDialogSequence(new string[]
				{
					"Neznámy: Psst... psst... slyšíš mě?",
					"Neznámy: Nepotřebuješ něco?",
					"Neznámy: Znám část kódu, od bedny 47",
					"Neznámy: Ale... můžu ti veřit?",
					"Neznámy: Ah detektiv, no dobře, tady máš kód:",
					"FRFE",
					"Neznámy: Ale... neříkej to nikomu, ano?"
				});
			}
			else if (clicks == 2)
			{
				dialogManager?.ShowDialog("Neznámy: Už jsem ti řekl, co vím. Neříkej to nikomu.");
			} else
			{
				dialogManager?.ShowDialog("Nic a nikdo tu není. (FRFE)");
			}
		}
	}
}
