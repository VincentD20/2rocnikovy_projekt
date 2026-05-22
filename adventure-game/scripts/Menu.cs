using Godot;
using System;

public partial class Menu : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	private Panel pausePanel;
	private Panel settingsPanel;
	private Button continueButton;
	private Button settingButton;
	private Button endButton;
	private HSlider volumeSlider;
	private Button backButton;
	private Button saveButton;
	public override void _Ready()
	{
		pausePanel = GetNode<Panel>("Panel");
		settingsPanel = GetNode<Panel>("Panel2");
		continueButton = GetNode<Button>("Panel/VBoxContainer/Continue");
		settingButton = GetNode<Button>("Panel/VBoxContainer/Settings");
		endButton = GetNode<Button>("Panel/VBoxContainer/End");
		volumeSlider = GetNode<HSlider>("Panel2/Volume");
		backButton = GetNode<Button>("Panel2/Back");
		saveButton = GetNode<Button>("Panel/VBoxContainer/Save");
		pausePanel.Visible = false;
		settingsPanel.Visible = false;
		ProcessMode = ProcessModeEnum.Always;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey keyEvent && keyEvent.Pressed)
		{
			if (keyEvent.Keycode == Key.Escape)
			{
				if(!pausePanel.Visible)
				{
					if (settingsPanel.Visible) {
						settingsPanel.Visible = false;
					}
					pausePanel.Visible = true;
					GetTree().Paused = true;
				} else 
				{
					pausePanel.Visible = false;
					GetTree().Paused = false;
				}
			}
		}
	}

	private void _on_continue_pressed()
	{
		GetTree().Paused = false;
		pausePanel.Visible = false;
	}
	private void _on_setting_pressed()
	{
		pausePanel.Visible = false;
		settingsPanel.Visible = true;
	}
	private void _on_end_pressed()
	{
		GetTree().Quit();
	}
	private void _on_back_pressed()
	{
		pausePanel.Visible = true;
		settingsPanel.Visible = false;
	}
	private void _on_volume_changed(float value)
	{
		AudioServer.SetBusVolumeDb(0, Mathf.LinearToDb(value));
	}

	private void _on_save_pressed() {
		GetNode<SaveManager>("/root/SaveManager").SaveGame();
	}
}
