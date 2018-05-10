using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragMoveItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    GameObject storage = null;
    GameObject Instantiate_gameobject;
    BaseItem item;
    BaseItem item_Instead;
    // Use this for initialization
    void Start()
    {
        storage = GameObject.Find("Bag/Toggroup/storage").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
     
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GetComponent<RectTransform>().pivot.Set(0, 0);
            transform.position = Input.mousePosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            item = ItemInfo.GetItem(transform.parent.name);
            ItemInfo.DeleteItem(transform.parent.name);

            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            Instantiate_gameobject = transform.parent.gameObject; //transform.parent是当前坐标的父物体 （使transform.parent得到当前坐标信息）
            transform.SetParent(storage.transform, true);
            transform.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            if (eventData.pointerCurrentRaycast.gameObject.tag == "UIBag")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                ItemInfo.StoreItem(eventData.pointerCurrentRaycast.gameObject.transform.name, item);

            }
            else if(eventData.pointerCurrentRaycast.gameObject.tag == "UItem")
            {

                Transform transformA = eventData.pointerCurrentRaycast.gameObject.transform;//transformA是当前鼠标位置所在物体的坐标信息
                Transform transformB_parent = transformA.parent.transform;//transformB_parent是transformA的父物体，transformB_parent得到transformA的坐标信息，也就是鼠标松开时，所在UItem物体的坐标

                item_Instead = ItemInfo.GetItem(eventData.pointerCurrentRaycast.gameObject.transform.parent.name);
                ItemInfo.DeleteItem(eventData.pointerCurrentRaycast.gameObject.transform.parent.name);

                transformA.SetParent(Instantiate_gameobject.transform, true);//transformA的父物体变成Instantiate_gameobject，transformA的坐标变为之前点击物体时的坐标，因为上一步已经将坐标信息给了transformB_parent
                transformA.localPosition = Vector3.zero;

                ItemInfo.StoreItem(Instantiate_gameobject.transform.name, item_Instead);

                transform.SetParent(transformB_parent);//当前坐标的父物体变为transformB_parent

                ItemInfo.StoreItem(transformB_parent.name, item);
            }
            //A是移动开始坐标，B是移动结束坐标,Instantiate_gameobject(C)是空，transformA(D)是空,transformB_parent(E)是空
            //C = A
            //D = B
            //E = D
            //D = C
            //B = E

            else
            {
                transform.SetParent(Instantiate_gameobject.transform, true);
                ItemInfo.StoreItem(Instantiate_gameobject.transform.name, item);
            }
        }
        transform.localPosition = Vector3.zero;
        transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }


}
