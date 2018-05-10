using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class Bag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //public bool Switch = false;
    public static Bag instance;
    public Text moneyCount;
    public float toSpeed;
    public float goSpeed;
    private PlayerHealth playerhealth;
    Vector3 offsetposition;
    /// <summary>
    /// 单例
    /// </summary>
    void Awake()
    {
        instance = this;
        moneyCount = transform.Find("moneybg/moneycount").GetComponent<Text>();
    }

    void Start()
    {
        playerhealth = GameObject.FindGameObjectWithTag(Tag.player).GetComponent<PlayerHealth>();


    }

    void Update()
    {
        moneyCount.text = playerhealth.money + "";

    }


    public void OnDrag(PointerEventData eventData)
    {

        var rt = gameObject.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
            {
                rt.position = globalMousePos + offsetposition;
            }
            transform.position = Input.mousePosition + offsetposition;
        }


    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        offsetposition = transform.position - Input.mousePosition;
        Debug.Log("拖动开始");


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("拖动结束");

    }



}
