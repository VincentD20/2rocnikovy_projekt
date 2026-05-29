using Godot;
using System;

public partial class NavigaceModul : Area2D
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
			GameState.RegisterClick("NavigaceModul");
			int clicks = GameState.GetClickCount("NavigaceModul");
			if (clicks == 1)
			{
				dialogManager?.ShowDialogSequence(new string[]
				{
					"Co to sakra...",
					"Navigační modul — stav: ZNIČENO",
					"Někdo záměrně přeprogramoval kurz stanice.",
					"A odvedli práci pečlivě. Příliš pečlivě.",
					"Stopy vedou k... [data smazána]"
				});
			}
			else
			{
				dialogManager?.ShowDialog("Modul je stále sabotovaný.");
			}
		}
	}
}
