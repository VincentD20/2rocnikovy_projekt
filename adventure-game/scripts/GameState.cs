using Godot;
using System;
using System.Collections.Generic;

public static class GameState
{
    public static Dictionary<string, int> ObjectClickCounts = new Dictionary<string, int>();
    public static int GetClickCount(string objectId)
    {
        return ObjectClickCounts.GetValueOrDefault(objectId, 0);
    }
    public static void RegisterClick(string objectId)
    {
        ObjectClickCounts[objectId] = GetClickCount(objectId) + 1;
    }
}
