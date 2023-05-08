using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// About The Class
/// GenStepTerrain is o
/// 

public class GenStepTerrain 
{
    public static void RunStep()
    {
        GenerateTerrain();
        GenerateMountains();        
    }
    private static void GenerateTerrain()
    {
        for (int x = 0; x < WorldData.settings.GetMapDimensons().x; x++)
        {
            
            for (int y = 0; y < WorldData.settings.GetMapDimensons().y; y++)
            {
                //Debug.Log(x + " " + y);
                for (int i = 0; i < WorldObjDatabase.terrainId; i++)
                {
                    //Debug.Log(x + " " + y);
                    if (WorldData.elevationMap.GetHeight(x, y) <= WorldObjDatabase.GetTerrainPlate(i).height.GetValue())
                    {
                        WorldData.groundMap.SetValue(x, y, new TerrainBase(WorldObjDatabase.GetTerrainPlate(i)));
                        WorldData.surfaceMap.SetTile((int)WorldObjDatabase.GetTerrainPlate(i).mapLayer.GetValue(), x, y, WorldObjDatabase.GetTerrainPlate(i).GetTile());
                        WorldData.surfaceMap.SetFlag((int)WorldObjDatabase.GetTerrainPlate(i).mapLayer.GetValue(), x, y, UnityEngine.Tilemaps.TileFlags.None);       
                        break;
                    }
                }
            }
        }
    }

    private static void GenerateMountains()
    {
        for (int x = 0; x < WorldData.settings.GetMapDimensons().x; x++)
        {
            for (int y = 0; y < WorldData.settings.GetMapDimensons().y; y++)
            {
                for (int i = 0; i < WorldObjDatabase.ResourceId; i++)
                {
                    //Debug.Log("ran");
                    if (WorldData.elevationMap.GetHeight(x, y) >= WorldObjDatabase.GetResourcePlate(i).height.GetValue())
                    {
                        WorldData.wallMap.SetValue(x, y, new ResourceBase(WorldObjDatabase.GetResourcePlate(i)));
                        WorldData.surfaceMap.SetTile(((int)WorldObjDatabase.GetResourcePlate(i).mapLayer.GetValue()), x, y, WorldObjDatabase.GetResourcePlate(i).GetTile());
                        WorldData.surfaceMap.SetFlag((int)WorldObjDatabase.GetResourcePlate(i).mapLayer.GetValue(), x, y, UnityEngine.Tilemaps.TileFlags.None);
                        break;
                    }
                }                  
            }
        }
    }

    
}
