using Godot;
using System;

public partial class VesmirnaStanice : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private Label dialogLabel;

	public override void _Ready()
	{
		dialogLabel = GetNode<Label>("CanvasLayer/Panel/Label");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ShowDialog(string text)
	{
		dialogLabel.Text = text;
	}
}
