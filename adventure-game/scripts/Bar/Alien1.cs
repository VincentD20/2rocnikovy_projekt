using Godot;
using System;

public partial class Alien1 : Area2D
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
			if (!Inventory.HasItem("Joke"))
			{
				Inventory.AddItem("Joke");
				dialogManager?.ShowDialogSequence(new string[] {
					"Chceš slyšet vtip?",
					"*někdo zaklepe na dveře*",
					"...ano?",
					"Proč černá díra nikdy nechodí na večírky?",
					"Protože vše pohltí a nikdo se nevrátí.",
					"*ticho*",
					"Tohle zkus na barmana. Funguje to. Věř mi."
				});
			}
			else
			{
				dialogManager?.ShowDialog("Už víš co potřebuješ. Jdi za barmanem.");
			}
		}
	}
}
