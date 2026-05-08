using Godot;
using System;
using System.Collections.Generic;

public static class Inventory
{
	public static List<string> Items = new List<string>();

	public static bool HasItem(string item)
	{
		return Items.Contains(item);
	}

	public static void AddItem(string item)
	{
		Items.Add(item);
	}
}
