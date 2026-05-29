using Godot;
using System;

public partial class Box : Area2D
{
	// Called when the node enters the scene tree for the first time.
	private CanvasLayer inputLayer;
	private LineEdit lineEdit;
	private Button confirmButton;
	private Panel inputPanel;
	public override void _Ready()
	{
		inputLayer = GetNode<CanvasLayer>("CanvasLayer");
		inputPanel = inputLayer.GetNode<Panel>("Panel");
		lineEdit = inputPanel.GetNode<LineEdit>("LineEdit");
		confirmButton = inputPanel.GetNode<Button>("Button");
		inputPanel.Visible = false;
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
			if (dialogManager.IsDialogVisible()) return;
			
			if (Inventory.HasItem("HolographicRecording"))
			{
				dialogManager.ShowDialog("Bedna již byla otevřena.");
				return;
			}
			inputPanel.Visible = true;
		}
	}

	private void _on_button_pressed()
	{
		inputPanel.Visible = false;
		var dialogManager = GetNode<DialogManager>("/root/DialogManager");
		if (lineEdit.Text == "4672-FRFE")
		{
			Inventory.AddItem("HolographicRecording");
			dialogManager.ShowDialog("Bedna otevřena, získal jsi záznam.");
		} else
		{
			dialogManager.ShowDialog("Nesprávné heslo.");
		}

	}
}
