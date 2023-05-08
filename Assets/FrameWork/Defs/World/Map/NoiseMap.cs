using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NoiseMap 
{
    private float[,] map = null;

    //todo,
    //make work with generating new chunks
    //could make it so that each map saves a copy of the settings 
    //or just make it so the gen settings can be pulled from, sense after game start they shouldn't be
    //changed
    public void CreateMap(Vector2Int mapDimensons, int seed, int octaves, float scale, float lacunarity, float persitance, Vector2 offset)
    {
        map = new float[mapDimensons.x, mapDimensons.y];

        Vector2[] octaveOfset = new Vector2[octaves];//making octaves come from differnt locations

        System.Random randNumGen = new System.Random(seed);
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = randNumGen.Next(-100000, 100000) + offset.x;
            float offsetY = randNumGen.Next(-100000, 100000) + offset.y;
            octaveOfset[i] = new Vector2(offsetX, offsetY);
        }

        if (scale <= 0)
        {
            scale = 0.001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        float halfWidth = mapDimensons.x / 2f;
        float halfHeight = mapDimensons.y / 2f;

        for (int y = 0; y < mapDimensons.y; y++)
        {
            for (int x = 0; x < mapDimensons.x; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = (x - halfWidth) / scale * frequency + octaveOfset[i].x;
                    float sampleY = (y - halfHeight) / scale * frequency + octaveOfset[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persitance;//persitance is between 0 and 1 menaing it decreases amplitude per octave
                    frequency *= lacunarity;//lacunarity is greater then 1 menaing frequency increases 
                }
                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }
                map[x, y] = noiseHeight;

            }
        }
        for (int y = 0; y < mapDimensons.y; y++)
        {
            for (int x = 0; x < mapDimensons.x; x++)
            {
                map[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, map[x, y]);
                //inverse lerp returns a value between 0 and 1, normalizeing the noise map
            }
        }
    }

    public float GetHeight(int x,int y)
    {
        return map[x, y];
    }

    public void UpdatePos(int x, int y,int value) {
        map[x, y] = value;
    }

    //todo
    //probably want a use offset an set player position
    //this is meant to allow the world to increase in size if max size isn't reached
    public void IncreaseMap()
    {
        //probally make a temp map 
    }


   

}
