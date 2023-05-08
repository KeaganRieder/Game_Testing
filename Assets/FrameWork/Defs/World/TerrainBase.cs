using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBase : WorldObjectBase
{
    public enum Type
    {
        Default = 0,
        Water = 1,
        Sand = 2,
        Dirt = 3,
        Grass = 4,
        Stone = 5,
    }
    //Terrain variables here
    public Type type;

    public void SetType(Type value)
    {
        type = value;
    }

    public TerrainBase(string name)
    {
        SetName(name);
    }
    public TerrainBase(string name, string description, Type type, Dictionary<string, float> statsList, BuildCost[] cost, BuildCost[] itemsDroped)
    {
        SetName(name);
        SetType(type);
        SetDescription(description);
        SetSpirtes(((int)statsList["Graphics"]));
        SetHieght(statsList["Height"]);
        SetMapLayer(statsList["Layer"]);
        SetMoisture(statsList["MoistureReq"]);
        SetTempature(statsList["TemperatureReq"]);
        SetFertility(statsList["Fertility"]);
        SetHitPoints(statsList["HitPoints"]);
        SetFlamability(statsList["Flammability"]);
        SetWalkSpeed(statsList["WalkSpeed"]);

        //SetBiuldCost(cost, cost.Length != 0 && cost != null);
        //SetDropedItems(itemsDroped, itemsDroped.Length != 0 && itemsDroped != null);
    }

    public TerrainBase(TerrainBase template)
    {
        SetName(template.name);
        SetType(template.type);
        SetDescription(template.description);
        SetSprites(template.graphics);
        SetHieght(template.height.GetValue());
        SetMapLayer(template.mapLayer.GetValue());
        SetMoisture(template.moisture.GetValue());
        SetTempature(template.tempature.GetValue());
        SetFertility(template.fertility.GetValue());
        SetHitPoints(template.hitPoints.GetValue());
        SetFlamability(template.flamability.GetValue());
        SetWalkSpeed(template.walkSpeed.GetValue());

        //SetBiuldCost(template.biuldCost, template.buildable);
        //SetDropedItems(template.dropedItems, template.dropsItems);
    }
    /*maybe try and make this a tile later
     * public static TerrainBase CreateInstance(string name, string description, Type type, Dictionary<string, float> statsList, BuildCost[] cost, BuildCost[] itemsDroped)
    {
        var data = ScriptableObject.CreateInstance<TerrainBase>();
        data.SetName(name);
        data.SetType(type);
        data.SetDescription(description);
        data.SetSpirtes(((int)statsList["Graphics"]));
        data.SetHieght(statsList["Height"]);
        data.SetMapLayer(statsList["Layer"]);
        data.SetMoisture(statsList["MoistureReq"]);
        data.SetTempature(statsList["TemperatureReq"]);
        data.SetFertility(statsList["Fertility"]);
        data.SetHitPoints(statsList["HitPoints"]);
        data.SetFlamability(statsList["Flammability"]);
        data.SetWalkSpeed(statsList["WalkSpeed"]);
        return data;

        //SetBiuldCost(cost, cost.Length != 0 && cost != null);
        //SetDropedItems(itemsDroped, itemsDroped.Length != 0 && itemsDroped != null);
    }

    public static TerrainBase CreateInstance(TerrainBase template)
    {
        var data = ScriptableObject.CreateInstance<TerrainBase>();
        data.SetName(template.name);
        data.SetType(template.type);
        data.SetDescription(template.description);
        data.SetSprites(template.graphics);
        data.SetHieght(template.height.GetValue());
        data.SetMapLayer(template.mapLayer.GetValue());
        data.SetMoisture(template.moisture.GetValue());
        data.SetTempature(template.tempature.GetValue());
        data.SetFertility(template.fertility.GetValue());
        data.SetHitPoints(template.hitPoints.GetValue());
        data.SetFlamability(template.flamability.GetValue());
        data.SetWalkSpeed(template.walkSpeed.GetValue());
        return data;

        //SetBiuldCost(template.biuldCost, template.buildable);
        //SetDropedItems(template.dropedItems, template.dropsItems);
    }
     */
}


