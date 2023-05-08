using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceBase : WorldObjectBase
{
    public enum Type
    {
        Default = 0,
        Mountain = 1,
        Scrap = 2,
        Coal = 3,
    }
    //resource variables here
    public Type type;

    public void SetType(Type value)
    {
        type = value;
    }

    //resource functions here
    public ResourceBase(string name)
    {
        SetName(name);
    }

    public ResourceBase(string name, string description, Type type, Dictionary<string, float> statsList, BuildCost[] cost, BuildCost[] itemsDroped)
    {
        SetName(name);
        SetType(type);
        SetDescription(description);
        SetSpirtes(((int)statsList["Graphics"]));
        SetSelectable(true);
        SetHieght(statsList["Height"]);
        SetMapLayer(statsList["Layer"]);
        SetMoisture(statsList["MoistureReq"]);
        SetTempature(statsList["TemperatureReq"]);
        SetFertility(statsList["Fertility"]);
        SetHitPoints(statsList["HitPoints"]);
        SetFlamability(statsList["Flammability"]);
        SetWalkSpeed(statsList["WalkSpeed"]);

        //SetBiuldCost(cost, cost.Length != 0 && cost != null);
       // SetDropedItems(itemsDroped, itemsDroped.Length != 0 && itemsDroped != null);
    }

    public ResourceBase(ResourceBase template)
    {
        SetName(template.name);
        SetType(template.type);
        SetDescription(template.description);
        SetSprites(template.graphics);
        SetSelectable(template.selectable);
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
}
