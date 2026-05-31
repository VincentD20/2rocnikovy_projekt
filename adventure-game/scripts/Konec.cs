using Godot;
using System;

public partial class Konec : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private Button button;
	public override void _Ready()
	{
		button = GetNode<Button>("Button");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/MainMenu.tscn");
	}
}
