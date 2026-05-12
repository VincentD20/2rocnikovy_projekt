using Godot;
using System;

public partial class InventoryUI : CanvasLayer
{
	private Panel panel;
	private List<string> inventoryItems;
	private Label itemLabel;

	public override void _Ready()
	{
		panel = GetNode<Panel>("Panel");
		itemLabel = GetNode<Label>("Panel/ItemLabel");
		inventoryItems = Inventory.Items;
		panel.Visible = false;

	}

	public void UpdateInventory()
	{
		foreach (Node child in panel.GetChildren())
		{
			child.QueueFree();
		}

		foreach (string item in inventoryItems)
		{
			itemLabel.Text = item;
			panel.AddChild(itemLabel);
		}
	}

}
