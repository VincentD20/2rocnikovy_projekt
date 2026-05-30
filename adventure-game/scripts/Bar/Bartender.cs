using Godot;
using System;

public partial class Bartender : Area2D
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
			if (Inventory.HasItem("Joke"))
			{
				if (Inventory.HasItem("Coin"))
				{
					Inventory.RemoveItem("Joke");
					Inventory.RemoveItem("Coin");
					Inventory.AddItem("GalacticTea");
					dialogManager?.ShowDialogSequence(new string[] {
						"Ha ha, ten byl dobrej :D",
						"Na tady máš ten čaj, ",
						" pokud máš pro mě ještě nějaký vtip, tak sem s ním."
					});
				}
				else
				{

					dialogManager?.ShowDialog("Nemáš prachy, tak nic nebude.");
				}
			}
			else
			{
				dialogManager?.ShowDialog("Hele, pokud pro mě nemáš žádný vtip, tak táhni někam jinam.");
			}
		}
	}
}
