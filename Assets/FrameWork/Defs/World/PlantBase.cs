using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBase : WorldObjectBase //todo
{
    //plant variables here


    //plant functions here
    public PlantBase(string name)
    {
        SetName(name);
    }
    public PlantBase(string name, string description, Dictionary<string, float> statsList, BuildCost[] cost, BuildCost[] itemsDroped)
    {
        SetName(name);
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

        SetBiuldCost(cost, cost.Length != 0 && cost != null);
        SetDropedItems(itemsDroped, itemsDroped.Length != 0 && itemsDroped != null);

    }
    public PlantBase(PlantBase template)
    {
        SetName(template.name);
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

        SetBiuldCost(template.biuldCost, template.buildable);
        SetDropedItems(template.dropedItems, template.dropsItems);
    }
}
