using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Text;


public class ShowInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Text Text_Description;
    Image image;
    GameObject bi;
    public float Speed=2000;
 
    bool infoSwitch = true;
    void Awake()
    {

    }
   
    void Start()
    {
        Text_Description = GameObject.Find("BagInfo").transform.Find("Description").gameObject.GetComponent<Text>();
        image = GameObject.Find("BagInfo").transform.Find("icon").gameObject.GetComponent<Image>();
        bi = GameObject.Find("BagInfo").gameObject;
      
      
    }

    // Update is called once per frame
    void Update()
    {
      

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("检测到物体");
        
        if(infoSwitch)
        {
            Debug.Log("信息界面打开");
            bi.transform.localPosition = Vector3.MoveTowards(bi.transform.localPosition, new Vector3(-25, -7, 0), Speed);
         //   bi.gameObject.SetActive(true);
            infoSwitch = false;
        }
       
        BaseItem item = ItemInfo.GetItem(eventData.pointerEnter.transform.parent.name);
      
        if (item == null)
        {
            return;
        }
        //处理物品显示标签的方法
        string texttmp = TogleItemToText(item);
        //将处理过的文字显示
        Text_Description.text = texttmp;
        image.overrideSprite = Resources.Load(item.Icon, typeof(Sprite)) as Sprite;
    

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("离开物品");
        if (!infoSwitch)
        {
            Debug.Log("信息界面关闭");
            bi.transform.localPosition = Vector3.MoveTowards(bi.transform.localPosition, new Vector3(-532, -7, 0), Speed);
         
            infoSwitch = true;
        }
      
     
    }

    private string TogleItemToText(BaseItem item)
    {
        if (item == null)
        {
            return "";
        }
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=red>{0}</color>\n", item.Name); 

        //类型
        switch (item.ItemsType)
        {
            case BaseItem.ItemType.Armor:
                Armor armor = (Armor)item;  //需要强转一下类型，父类成员可以强转成子类
                sb.AppendFormat("防御：{0}\n\n", armor.Defense);
                break;
            case BaseItem.ItemType.Weapons:
                Weapons weapon = item as Weapons;
                sb.AppendFormat("攻击力：{0}\n", weapon.Attack);
                break;
            case BaseItem.ItemType.Consumables:
                Consumables consumable = item as Consumables;
                sb.AppendFormat("HP：{0}\n\n", consumable.BackHP);
                break;
            default: break;
        }

        //公有属性
        sb.AppendFormat("购买价格：{0}贩卖价格：{1}描述：{2}", item.BuyPrice, item.SellPrice, item.Description);

        return sb.ToString();
    }

   
}
