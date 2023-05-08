using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ItemBase 
{
    public string name;
    public string description;
    public List<Sprite> graphics = new List<Sprite>();

    //object info maybe add more to base object info
    public Stat hitPoints;
    public Stat flamability;
    public BuildCost[] craftCost = null;
    public bool craftAble;
    public bool canStack;

    public void SetName(string name) { this.name = name; }
    public void SetDescription(string description) { this.description = description; }
    public void SetGraphics(int varients)
    {
        for (int i = 0; i < varients; i++)
        {
            if (Resources.Load<SpriteAtlas>("GraphicManger").GetSprite(this.name + "_" + i) == null)
            {
                graphics.Add(Resources.Load<SpriteAtlas>("GraphicManger").GetSprite("Default_Texture"));
            }
            else
            {
                graphics.Add(Resources.Load<SpriteAtlas>("GraphicManger").GetSprite(name + "_" + i));
            }
        }
    }
    public void SetGraphics(List<Sprite> graphics) { this.graphics = graphics; }
    public void SetHitPoints(float value) { hitPoints.SetValue(value); }
    public void SetFlamability(float value) { flamability.SetValue(value); }
    public void SetStackability(bool stackable)
    {
        canStack = stackable;
    }
    public void SetCraftCost(BuildCost[] cost)
    {
        if (cost.Length > 0 || cost != null)
        {
            craftCost = cost;
            craftAble = true;
        }
        else
        {
            craftCost = null;
            craftAble = false;
        }
        
    }


}
