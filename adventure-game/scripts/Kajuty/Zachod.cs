using Godot;
using System;

public partial class Zachod : Area2D
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
			GameState.RegisterClick("Zachod");
			int clicks = GameState.GetClickCount("Zachod"); 
			if (clicks == 1)
			{
				dialogManager?.ShowDialogSequence(new string[]
				{
					"*přiložíš ucho ke dveřím*",
					"Slyšíš podivné zvuky... jako by někdo nebo něco dýchalo.",
					"A pak ticho.(Radil bych ti to nezkoušet znovu, ale... je to na tobě.)",
					"já tě varoval...",
					"Máš štěstí, že je to zamčené."
				});
			}
			else if (clicks < 4)
			{
				dialogManager?.ShowDialog("Stále tam něco je. Neotvírej to.");
			}
			else if (clicks == 4)
			{
				dialogManager?.ShowDialog("Pokud to chceš otevřít, budeš muset ...");
			}
			else if (clicks == 5)
			{
				dialogManager?.ShowDialog("...z..ale, ne... to je ...!!");
			} else
			{
				dialogManager?.ShowDialog("...... ... ...");
			}

		}
	}
}
