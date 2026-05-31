using Godot;
using System;

public partial class MainMenu : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private Button loadButton;
	public override void _Ready()
	{
		loadButton = GetNode<Button>("VBoxContainer/Button4");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_Hrat_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/VesmirnaStanice.tscn");
	}

	private void _on_Konec_pressed()
	{
		GetTree().Quit();
	}

	private void _on_load_pressed()
	{
		GetNode<SaveManager>("/root/SaveManager").LoadGame();
	}


}
