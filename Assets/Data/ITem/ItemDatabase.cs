using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase
{
    public static int resourceID = 0;
    public static int weaponID = 0;
    public static int armorID = 0;

    private static Dictionary<int, ItemBase> resourceItemDatabase = new Dictionary<int, ItemBase>
    {

    };
    private static Dictionary<int, ItemBase> weaponDatabase = new Dictionary<int, ItemBase>
    {

    };
    private static Dictionary<int, ItemBase> armorDatabase = new Dictionary<int, ItemBase>
    {

    };

    public static ItemBase GetResourceItem(int id)
    {
        return resourceItemDatabase[id];
    }
    public static ItemBase GetWeapon(int id)
    {
        return armorDatabase[id];
    }
    public static ItemBase GetArmor(int id)
    {
        return weaponDatabase[id];
    }

    public static void AddResourceItem(ItemBase item)
    {
        resourceItemDatabase.Add(resourceID++, item);
    }
    public static void AddArmorItem(ItemBase item)
    {
        armorDatabase.Add(armorID++, item);
    }
    public static void AddWeaponItem(ItemBase item)
    {
        weaponDatabase.Add(weaponID++, item);
    }
}
