using Godot;
using System;

public partial class Zprava : Area2D
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
			if (Inventory.HasItem("Decoder"))
			{
				dialogManager?.ShowDialogSequence(new string[]
				{
					"DEŠIFROVÁNÍ... HOTOVO.",
					"ODESÍLATEL: Dr. Vesmírník",
					"PŘÍJEMCE: Intergalaktická rada",
					"Černá díra č.42 není ztracená.",
					"Odešla dobrovolně. Byl jsem svědkem.",
					"Nepátrejte po mně. Jsem tam kde musím být.",
					"— Dr. V."
				});
			}
			else
			{
				dialogManager?.ShowDialog("Zpráva je zašifrovaná. Potřebuješ dekodér.");
			}

		}
	}

}
