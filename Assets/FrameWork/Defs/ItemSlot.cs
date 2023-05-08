using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot 
{
    private ItemBase item = null;
    private int itemCount = 0;

    public void setItem(ItemBase itemToAdd)
    {
        //make check for stackable when implemented
        if (itemToAdd == item && itemToAdd.canStack)
        {
            itemCount++;
        }
        else
        {
            item = itemToAdd;
            itemCount = 1;
        }
    }
    public ItemBase Removeitem()
    {
        if (item != null)
        {
            if (itemCount == 1)
            {
                ItemBase takenItem = item;
                item = null;
                itemCount--;
                return takenItem;
            }
        }
        return null;
    }
    public int GetCount()
    {
        return itemCount;
    }

}
