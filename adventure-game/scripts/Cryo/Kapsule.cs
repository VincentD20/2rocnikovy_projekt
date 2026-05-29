using Godot;
using System;

public partial class Kapsule : Area2D
{
    private ColorRect colorRect;
    private bool isFrozen = false;
    private double freezeStartTime = 0;
    private const double freezeDuration = 10.0;
	private bool pendingFreeze = false;

    public override void _Ready()
    {
        colorRect = GetNode<ColorRect>("ColorRect");
        colorRect.Visible = false;
        ProcessMode = ProcessModeEnum.Always;
    }


	public override void _Process(double delta)
	{
		// check if dialog was dismissed and freeze is pending
		if (pendingFreeze)
		{
			var dialogManager = GetNode<DialogManager>("/root/DialogManager");
			if (!dialogManager.IsDialogVisible())
			{
				pendingFreeze = false;
				colorRect.Visible = true;
				isFrozen = true;
				freezeStartTime = Time.GetUnixTimeFromSystem();
				Engine.TimeScale = 0;
			}
		}

		if (!isFrozen) return;
		
		double elapsed = Time.GetUnixTimeFromSystem() - freezeStartTime;
		if (elapsed >= freezeDuration)
		{
			isFrozen = false;
			colorRect.Visible = false;
			Engine.TimeScale = 1;
			var dialogManager = GetNode<DialogManager>("/root/DialogManager");
			dialogManager?.ShowDialog("Dobrý co ...");
		}
	}

    public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
        {
            if (isFrozen) return;
            
            GameState.RegisterClick("Kapsule");
            int clicks = GameState.GetClickCount("Kapsule");
            var dialogManager = GetNode<DialogManager>("/root/DialogManager");

            if (clicks == 1)
                dialogManager?.ShowDialog("Ještě teplá.");
            else if (clicks == 2)
                dialogManager?.ShowDialog("Nechceš to zkusit?");
            else if (clicks == 3)
            {
                dialogManager?.ShowDialog("OK, jdeme na to.");
				pendingFreeze = true;
            }
        }
    }
}