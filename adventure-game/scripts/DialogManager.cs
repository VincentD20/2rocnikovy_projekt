using Godot;
using System.Collections.Generic;

public partial class DialogManager : CanvasLayer
{
	private Panel panel;
	private Label label;
	private AudioStreamPlayer audioPlayer;
	private Timer timer;
	
	private string fullText = "";
	private int currentIndex = 0;

	private Queue<string> dialogQueue = new Queue<string>();

	public override void _Ready()
	{
		// get references to your child nodes
		// hide the panel on start
		// connect the timer's Timeout signal to a method
		panel = GetNode<Panel>("Panel");
		label = panel.GetNode<Label>("Label");
		audioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		timer = GetNode<Timer>("Timer");
		HideDialog();
		timer.Timeout += OnTimerTimeout;
		timer.WaitTime = 0.05f;
	}

	public void ShowDialog(string text)
	{
		// store the full text
		// reset currentIndex to 0
		// clear the label
		// show the panel
		// start the timer
		fullText = text;
		currentIndex = 0;
		label.Text = "";
		panel.Visible = true;
		timer.Start();
	}

	private void OnTimerTimeout()
	{
		if(currentIndex < fullText.Length)
		{
			label.Text += fullText[currentIndex];
			audioPlayer.Play();
			currentIndex++;
		}
		else
		{
			timer.Stop();
		}
	}

	public void HideDialog()
	{
		panel.Visible = false;
		timer.Stop();
	}

	public override void _Input(InputEvent @event)
	{
		if (!panel.Visible) return;
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
			if (label.Text == fullText) {
				if (dialogQueue.Count > 0) {
					ShowDialog(dialogQueue.Dequeue());
				} else {
					HideDialog();
				}
			} else {
				timer.Stop();
				label.Text = fullText;
			}

		}
	}

	public void ShowDialogSequence(string[] interactions)
	{
    	dialogQueue.Clear();
		foreach(string interaction in interactions)
		{
			dialogQueue.Enqueue(interaction);
		}
		ShowDialog(dialogQueue.Dequeue());
	}


}
