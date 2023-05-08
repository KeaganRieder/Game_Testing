using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// and objects stat
/// </summary>
public class Stat 
{
    private float baseValue;
    private List<float> modifiers = new List<float>();

    public void SetValue(float value)
    {
        baseValue = value;
    }
    public float GetValue()
    {
        float finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }
    public void AddModifer(float modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
        
    }
    public void RemoveModifer(float modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }

    
}

