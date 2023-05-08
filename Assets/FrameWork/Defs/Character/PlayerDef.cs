using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDef : CharacterBase
{
    public PlayerDef(string name, GameObject body, Dictionary<string, float> stats)
    {
        SetName(name);
        SetBody(body);
        SetHealth(stats["Health"]);
        SetStamina(stats["Stamina"]);
        SetMoveSpeed(stats["MoveSpeed"]);
        SetDamage(stats["Damage"]);    
    }

    //player stat functions
}
