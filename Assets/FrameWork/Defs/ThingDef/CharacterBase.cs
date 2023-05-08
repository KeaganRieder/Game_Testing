using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase
{
    //base info
    public string name;
    public GameObject body; //make into own script later like stats
    //public 

    //stats
    public Stat health = new();
    public Stat stamina = new();
    public Stat moveSpeed = new();
    public Stat damage = new();
    //public Stat health = new();

    //inventory stuff

    //functions
    public void SetName(string value) { name = value; }
    public void SetHealth(float value) { health.SetValue(value); }
    public void SetStamina(float value) { health.SetValue(value); }
    public void SetMoveSpeed(float value) { moveSpeed.SetValue(value); }
    public void SetDamage(float value) { health.SetValue(value); }
    public void SetBody(GameObject value) { body = value; }

    //invetory functions

}
