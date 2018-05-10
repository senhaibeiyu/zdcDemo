using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : BaseItem
{
    public int BackHP { get;  set; }
  
    public Consumables(int id, string name, string description, int buyPrice, int sellPrice, string icon,int backhp) : base(id, name, description, buyPrice, sellPrice, icon)
    {
        this.BackHP = backhp;
        base.ItemsType = ItemType.Consumables;
    }
}
