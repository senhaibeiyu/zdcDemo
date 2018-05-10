using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem {
   
    public enum ItemType
    {
        Weapons,
        Armor,
        Consumables
    }

    public int ID { get;  set; }
    public string Name { get;  set; }
    public string Description { get;  set; }
    public int BuyPrice { get;  set; }
    public int SellPrice { get;  set; }
    public string Icon { get;  set; }
    public ItemType ItemsType { get; set; }

    public BaseItem(int id,string name,string description, int buyPrice,int sellPrice,string icon)
    {
        this.ID = id;
        this.Name = name;
        this.Description = description;
        this.BuyPrice = buyPrice;
        this.SellPrice = sellPrice;
        this.Icon = icon;
    }
  
}
