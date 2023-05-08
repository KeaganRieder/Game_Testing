using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationSettings
{
    private static Dictionary<string, float> genSettings;
    private static Vector2Int mapDimensions;
    public void Default()
    {
        genSettings = new Dictionary<string, float>
        {
            {"Seed", 10},//Random.Range(1, 5000)},
            {"Octaves",50},
            {"Scale", 50},
            {"Temperature",0.286f },
            {"Moisture",0.286f },
            {"Amplitude",0.286f },
            {"Frequency",2.9f },
            {"MaxMapWidth",500},
            {"MaxMapHeight",500},
        };
        mapDimensions = new Vector2Int(100,100);//base value
    }

    public void SetSetting(string setting, float Value)
    {
        genSettings[setting] = Value;
    }
    public void SetMapWidth(int value)
    {
        mapDimensions.x = value;
    }
    public void SetMapHeight(int value)
    {
        mapDimensions.y = value;
    }
    public float Get(string setting)
    {
        return genSettings[setting];
    }
    public Vector2Int GetMapDimensons()
    {
        return mapDimensions;
    }

    /*

    private static int seed;
    private static int octaves;
    private static int scale;
    private static float amplitude;
    private static float moisture;
    private static float temperature;
    private static float frequency;
    

    public void Default()
    {
        seed = Random.Range(1, 5000);
        octaves = 50;
        scale = 50;
        temperature = 0.286f;//amplitude for tempMap
        moisture = 0.286f;//amplitude for moistureMap
        amplitude = 0.286f;
        frequency = 2.9f;
        mapDimensions.x = 100;
        mapDimensions.y = 100;
    }

    public void SetOctave(int value)
    {
        octaves = value;
    }    
    public void SetSeed(int value)
    {
        seed = value;
    }   
    public void SetScale(int value)
    {
        scale = value;
    }    
    public void SetMapSizeX(int x)
    {
        mapDimensions.x = x;
    }    
    public void SetMapSizeY(int y)
    {
        mapDimensions.y = y;
    }    
    public void SetAmplitude(float value)
    {
        amplitude = value;
    }
    public void SetTempature(float value)
    {
        temperature = value;
    } 
    public void SetMoisture(float value)
    {
        moisture = value;
    }
    public void SetFrequancy(float value)
    {
        frequency = value;
    }

    public int GetOctaves()
    {
        return octaves;
    }
    public int GetSeed()
    {
        return seed;
    }
    public int GetScale()
    {
        return scale;
    }
    
    public float GetAmplitude()
    {
        return amplitude;
    }
    public float GetTempature()
    {
        return temperature;
    }
    public float GetMoisture()
    {
        return moisture;
    }
    public float GetFrequancy()
    {
       return frequency;
    }
*/
}
