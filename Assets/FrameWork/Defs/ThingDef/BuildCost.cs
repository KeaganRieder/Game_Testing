using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// info about either the cost to build an object or how much of 
/// an item it drops
/// </summary>
public class BuildCost 
{
    private int baseValue;
    private ItemBase item;
    private List<int> modifiers = new List<int>();//maybe make this a float for a percentage?

    public void SetValue(int value)
    {
        baseValue = value;
    }
    public void SetItem(ItemBase value)
    {
        item = value;
    }

    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }
    public ItemBase GetItem()
    {
        return item;
    }

    public void AddModifer(int modifier)
    {
        modifiers.Add(modifier);
    }
    public void RemoveModifer(int modifier)
    {
        modifiers.Remove(modifier);
    }



}

