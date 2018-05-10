using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Armor : BaseItem
    {
        public int Defense { get;  set; }
        public Armor(int id, string name, string description, int buyPrice, int sellPrice, string icon, int defense) : base(id, name, description, buyPrice, sellPrice, icon)
        {
            this.Defense = defense;
           base.ItemsType = ItemType.Armor;
        }


    }

