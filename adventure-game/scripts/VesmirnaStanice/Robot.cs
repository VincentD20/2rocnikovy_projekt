using Godot;
using System;

public partial class Robot : Area2D
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
			VesmirnaStanice scene = GetParent<VesmirnaStanice>();
			scene.ShowDialog("Já jsem robot HAL- 9001. Neviděl jsem žádnou černou díru. Opravdu.");
		}
	}
}
