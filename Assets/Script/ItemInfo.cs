using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{

    private static Dictionary<string, BaseItem> gridItem = new Dictionary<string, BaseItem>();

    public static void StoreItem(string name, BaseItem item)
    {
        if (gridItem.ContainsKey(name))
            return;
        gridItem.Add(name, item);
    }

    public static void DeleteItem(string name)
    {
        if (gridItem.ContainsKey(name))

            gridItem.Remove(name);
    } 
    public static BaseItem GetItem(string name)
    {
        if (gridItem.ContainsKey(name))
        {
            return gridItem[name];
        }
        else
            return null;
    }
}
