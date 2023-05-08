using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGeneration : MonoBehaviour
{
    //WorldData worldData = new();
    public List<Tilemap> temp;
    private void GenerateWorld()
    {
        //setting tile maps
        foreach (Transform Tilemap in GameObject.Find("GroundMap").transform)
        {
            WorldData.surfaceMap.AddMap(Tilemap.GetComponent<Tilemap>());
            temp.Add(Tilemap.GetComponent<Tilemap>());
        }

        WorldData.CreateMaps();
        GenStepTerrain.RunStep();
    }
    private void Start()
    {
        GenerateWorld();
    }
}
