using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : BaseItem {
    public int Attack { get;  set; }
 
    public Weapons(int id, string name, string description, int buyPrice, int sellPrice, string icon,int attack):base(id,name,description,buyPrice,sellPrice,icon)
    {
        this.Attack = attack;
        //base.ItemsType = ItemType.Weapons;
    }
   
}
