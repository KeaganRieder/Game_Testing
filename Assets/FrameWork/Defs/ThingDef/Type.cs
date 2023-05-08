using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type //check if this is a good idea or not
{
    public enum ObjectType
    {
        Enviorment,
        Biulding,
        Charcter,
        Item,
        Other,
    }
    private enum EnviormnetType
    {
        Resource,
        Terrain,
        Plant,
        Other,
    }
    private enum Item
    {
        Resource,
        Equipment,
        Other,
    }

    public bool buildable;



}
