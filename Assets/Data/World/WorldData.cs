using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// about class
/// 

public class WorldData 
{
    //saveFile Stuff
    //private string SAVE_FOLDER = Application.dataPath + "/Data/GameData/World/";
    //private string SAVE_FILE = "GeneartionData.json";

    //gen Data
    public static GenerationSettings settings = new(); //maybe get rid of

    //noise maps
    public static NoiseMap elevationMap = new();
    public static NoiseMap topographicMap = new();
    public static NoiseMap temperatureMap = new();
    public static NoiseMap precipitaionMap = new();
    public static NoiseMap resource = new();

    //Generation maps 
   // public static List<EnviormentMap<EnviormentBase>> maplayers = new();
    public static EnviormentMap<TerrainBase> groundMap = new();
    public static EnviormentMap<ResourceBase> wallMap = new();
    public static EnviormentMap<ResourceBase> resourceMap = new();
    public static EnviormentMap<PlantBase> plantMap = new();

    public static Map surfaceMap = new();    

    //creating noise maps used for world gen
    public static void CreateMaps()
    {
        settings.Default();//move somewhere else when this can be change by input
        elevationMap.CreateMap(settings.GetMapDimensons(), ((int)settings.Get("Seed")), ((int)settings.Get("Octaves")), settings.Get("Scale"),
            settings.Get("Frequency"), settings.Get("Amplitude"),new Vector2(0,0));

        topographicMap.CreateMap(settings.GetMapDimensons(), ((int)settings.Get("Seed")), ((int)settings.Get("Octaves")), settings.Get("Scale"),
            settings.Get("Frequency"), settings.Get("Amplitude"), new Vector2(0, 0));

        temperatureMap.CreateMap(settings.GetMapDimensons(), ((int)settings.Get("Seed")), ((int)settings.Get("Octaves")), settings.Get("Scale"),
            settings.Get("Frequency"), settings.Get("Temperature"), new Vector2(0, 0));

        precipitaionMap.CreateMap(settings.GetMapDimensons(),  ((int)settings.Get("Seed")), ((int)settings.Get("Octaves")), settings.Get("Scale"),
            settings.Get("Frequency"), settings.Get("Moisture"), new Vector2(0, 0));

        resource.CreateMap(settings.GetMapDimensons(),  ((int)settings.Get("Seed")), ((int)settings.Get("Octaves")), settings.Get("Scale"),
            settings.Get("Frequency"), settings.Get("Amplitude"), new Vector2(0, 0));

        groundMap.CreateMap(settings.GetMapDimensons(), null);
        wallMap.CreateMap(settings.GetMapDimensons(), null);
        resourceMap.CreateMap(settings.GetMapDimensons(), null);
        plantMap.CreateMap(settings.GetMapDimensons(), null);
    }

    /// <summary>
    /// checks the wall/resource maps for interactable/resources
    /// <returns></returns>
    public static void CheckForResource(int x, int y) //move this somewhere else at least the interaction part should get moved to world interaction
    {
        //Vector2 CurrentSelected = new Vector2(x, y);
        if (surfaceMap.CheckLayer(3,x,y) != null)
        {
            if (wallMap.GetValue(x, y).selectable) 
            {
                surfaceMap.SelectTile(3, x, y);
                Debug.Log("selected HP:" + wallMap.GetValue(x, y).hitPoints.GetValue());
                Debug.Log("_____________");
                wallMap.GetValue(x, y).hitPoints.AddModifer(-10);
                if (wallMap.GetValue(x, y).hitPoints.GetValue() <= 0)
                {
                     surfaceMap.SetTile(3, x, y, null);
                     wallMap.SetValue(x, y, null);
                }
            }
        }
        else
        {
            surfaceMap.UnSelectTile(3, x, y);
        }
        
    }

    public static void CheckGroundMap()
    {

    }
    public static void CheckPlantMap()
    {

    }

    public void save()
    {

    }
    public void load()
    {

    }

    


}
