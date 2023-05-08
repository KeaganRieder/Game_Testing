using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// about the class
/// using constructors defined by world object base class to define stats/characteristics
/// to later be used in the creation of world objects
public class WorldObjDatabase 
{
    //redo Ids later, and make it more specific
    public static int terrainId = 0; 
    public static int ResourceId = 0;
    public static int PlantId = 0;

    //maybe put this into a function which runs depending on weather game is first made or loaded

    /*probably wanna make it so the id is in a range so everything is seperated
    //like stone tiles are id between 100-200 and water is something like 0-50*/

    /// Structure for a terrainBase constructor 
    /// 
    
    private static Dictionary<int, TerrainBase> terrainDatabase = new Dictionary<int, TerrainBase>
    {
       // {0,new TerrainBase("DefaultTerrain")},
        {terrainId++,new TerrainBase("Deep_Ocean",
                "None", TerrainBase.Type.Water,
                new Dictionary<string, float>
                {
                    {"Graphics", 1 },
                    {"Height", .1f},
                    {"Layer", 0 },
                    {"MoistureReq",1 },
                    {"TemperatureReq", 1 },
                    {"Fertility", 0 },
                    {"HitPoints", 100},
                    {"Flammability", 0 },
                    {"WalkSpeed", .3f },
                },
                null,
                null
                ) 
        },
        {terrainId++,new TerrainBase("Shallow_Ocean",
                "None", TerrainBase.Type.Water,
                new Dictionary<string, float>
                {
                    {"Graphics", 1 },
                    {"Height", .3f},
                    {"Layer", 0 },
                    {"MoistureReq",1 },
                    {"TemperatureReq", 1 },
                    {"Fertility", 0 },
                    {"HitPoints", 100},
                    {"Flammability", 0 },
                    {"WalkSpeed", .4f },
                },
                null,
                null
                )
        },
        {terrainId++,new TerrainBase("Sand",
                "None", TerrainBase.Type.Sand,
                new Dictionary<string, float>
                {
                    {"Graphics", 3 },
                    {"Height", .4f},
                    {"Layer", 1 },
                    {"MoistureReq", 0 },
                    {"TemperatureReq", 0 },
                    {"Fertility", 0 },
                    {"HitPoints", 100},
                    {"Flammability", 0 },
                    {"WalkSpeed", .8f },
                },
                null,
                null
                )
        },
        {terrainId++,new TerrainBase("Grass",
                "None", TerrainBase.Type.Grass,
                new Dictionary<string, float>
                {
                    {"Graphics", 1 },
                    {"Height", .7f},
                    {"Layer", 1 },
                    {"MoistureReq",1 },
                    {"TemperatureReq", 1 },
                    {"Fertility", 100 },
                    {"HitPoints", 100},
                    {"Flammability", 1 },
                    {"WalkSpeed", 1f },
                },
                null,
                null
                )
        },
        {terrainId++,new TerrainBase("Dirt",
                "None", TerrainBase.Type.Dirt,
                new Dictionary<string, float>
                {
                    {"Graphics", 3 },
                    {"Height", .1f},
                    {"Layer", 1 },
                    {"MoistureReq",.5f },
                    {"TemperatureReq", 1 },
                    {"Fertility", 0 },
                    {"HitPoints", 100},
                    {"Flammability", 0},
                    {"WalkSpeed", .8f },
                },
                null,
                null
                )
        },
        {terrainId++,new TerrainBase("Stone",
                "None", TerrainBase.Type.Stone,
                new Dictionary<string, float>
                {
                    {"Graphics", 1 },
                    {"Height", 1f},
                    {"Layer", 1 },
                    {"MoistureReq",0 },
                    {"TemperatureReq", 0 },
                    {"Fertility", 0 },
                    {"HitPoints", 100},
                    {"Flammability", 0 },
                    {"WalkSpeed", .7f },
                },
                null,
                null
                )
        },
    };
    /// Structure for a ResourceBase constructor 
    /// 
    private static Dictionary<int, ResourceBase> resoucreDatabase = new Dictionary<int, ResourceBase>
    {
        //make default resource
        {ResourceId++,new ResourceBase("Stone",
                "None", ResourceBase.Type.Mountain,
                new Dictionary<string, float>
                {
                    {"Graphics", 1 },
                    {"Height", .75f},
                    {"Layer", 3 },
                    {"MoistureReq",0 },
                    {"TemperatureReq", 0 },
                    {"Fertility", 0 },
                    {"HitPoints", 100},
                    {"Flammability", 0 },
                    {"WalkSpeed", .7f },
                },
                null,
                null
                )
        },
    };
    /// Structure for a PlantBase constructor 
    /// 
    private static Dictionary<int, PlantBase> plantDatabase = new Dictionary<int, PlantBase>
    {
        //make defualtPlant
    };

    public static TerrainBase GetTerrainPlate(int id)
    {
        return terrainDatabase[id];
    }
    public static TerrainBase GetTerrainPlate(float height)
    {
        foreach (var terrain in terrainDatabase.Values)
        {
            if (terrain.height.GetValue() == height)
            {
                return terrain;
            }
        }
        return null;        
    }
    public static TerrainBase GetTerrainPlate(TerrainBase.Type type)
    {
        foreach (var terrain in terrainDatabase.Values)
        {
            if (terrain.type == type)
            {
                return terrain;
            }
        }
        return null;
    }
    public static ResourceBase GetResourcePlate(int id)
    {
        return resoucreDatabase[id];
    }
    public static ResourceBase GetResourcePlate(float height)
    {
        foreach (var resource in resoucreDatabase.Values)
        {
            if (resource.height.GetValue() == height)
            {
                return new(resource);
            }
        }
        return null;
    }
    public static PlantBase GetPlantPlate(int id)
    {
        return plantDatabase[id];
    }
    public static PlantBase GetPlantPlate(float height)
    {
        foreach (var plant in plantDatabase.Values)
        {
            if (plant.height.GetValue() == height)
            {
                return new(plant);
            }
        }
        return null;
    }

    //add fucntions
    public static void AddTerrain(TerrainBase terrain)
    {
        terrainDatabase.Add(PlantId++, terrain);
    }
    public static void AddResource(ResourceBase resource)
    {
        resoucreDatabase.Add(PlantId++, resource);
    }
    public static void AddPlant(PlantBase plant)
    {
        plantDatabase.Add(PlantId++, plant);
    }

    //to do
    //maybe just make this apart of the add functions
    public static void CreateTerrainFromFile()
    {
        //terrainId++;
        TerrainBase debug = new("debug");
        AddTerrain(debug);
    }
    public static void CreateResourceFromFile()
    {
        //ResourceId++;
        ResourceBase debug = new("debug");
        //debug.SetName();
        AddResource(debug);
    }
    public static void CreatePlantFromFile()
    {
        //PlantId++;
        PlantBase debug = new("debug");
        AddPlant(debug);

    }  
}
