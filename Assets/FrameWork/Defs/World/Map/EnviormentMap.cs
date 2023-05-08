using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviormentMap<value> //combine with map classs
{
    //if doesn't work try a generic template class type t 
    private value[,] map; //check how to do generic class type

   // private <T>[,] map;
    public void CreateMap(Vector2Int mapDimensions, value pos)
    {
        map = new value[mapDimensions.x, mapDimensions.y];
        for (int x = 0; x < mapDimensions.x; x++)
        {
            for (int y = 0; y < mapDimensions.y; y++)
            {
                map[x, y] = pos;
            }
        }
    }
    public void SetValue(int x, int y, value value)
    {
        map[x, y] = value;
    }
    public value GetValue(int x, int y)
    {
        return map[x, y];
    }


    

}
