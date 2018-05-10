using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class shopNPC : MonoBehaviour
{

    private bool ShopSwitch = false;
    public GameObject shop;
    public GameObject Buy;
   // private BagManager bagmanager;
   // public static Dictionary<int, BaseItem> ItemList;
    void Awake()
    {
       // bagmanager = GameObject.Find("Bag").transform.Find("/Toggroup/tog1Panel/Grid").gameObject.GetComponent<BagManager>();
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {


        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {

                Switch();
            }
        }
       
    }

    /// <summary>
    /// 判断是否点击商人NPC
    /// </summary>
    void Switch()
    {
        if (ShopSwitch == false)
        {
            ShopSwitch = true;
            GetComponent<AudioSource>().Play();
            shop.gameObject.SetActive(true);
        }
        else
        {
            ShopSwitch = false;
            shop.gameObject.SetActive(false);
        }

    }

    public void OnCloseButton()
    {
        shop.gameObject.SetActive(false);
    }

    public void OnOKbutton()
    {
        Buy.SetActive(true);
    }
    public void Ongetitem()
    {
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        // ItemList = new Dictionary<int, BaseItem>();
            //}
    }
    public void OnBuyCloseButton()
    {
        Buy.SetActive(false);
    }
}
