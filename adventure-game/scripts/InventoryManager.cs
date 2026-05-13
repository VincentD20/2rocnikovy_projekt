using Godot;
using System;

public partial class InventoryManager : CanvasLayer
{
	private Panel panel;
	private ItemList itemList;

	public override void _Ready()
	{
		panel = GetNode<Panel>("Panel");
		itemList = panel.GetNode<ItemList>("ItemList");
		panel.Visible = false;

	}

	public void ShowInventory()
	{
		UpdateInventory();
		panel.Visible = true;
	}

	public void HideInventory()
	{
		panel.Visible = false;
	}



	public void UpdateInventory()
	{
		itemList.Clear();
		foreach (string item in Inventory.Items)
		{
			itemList.AddItem(item);
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey keyEvent && keyEvent.Pressed)
		{
			if (keyEvent.Keycode == Key.I)
			{
				if (panel.Visible)
					HideInventory();
				else
					ShowInventory();
			}

		}
	}

}
