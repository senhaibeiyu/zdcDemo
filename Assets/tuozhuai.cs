using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class tuozhuai : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
        //并将拖拽时的坐标给予被拖拽对象的代替品
        //Vector3 pos;
        //if (RectTransformUtility.ScreenPointToWorldPointInRectangle(drag_icon.GetComponent<RectTransform>(),
        //     eventData.position, Camera.main, out pos))
        //{
        //    drag_icon.transform.position = pos;
        //}
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
        ////代替品实例化
        //drag_icon = new GameObject("icon");
        //drag_icon.transform.SetParent(GameObject.Find("Canvas").transform, false);
        //drag_icon.AddComponent<RectTransform>();
        //var img = drag_icon.AddComponent<Image>();
        //img.sprite = this.GetComponent<Image>().sprite;

        ////防止拖拽结束时，代替品挡住了准备覆盖的对象而使得 OnDrop（） 无效
        //CanvasGroup group = drag_icon.AddComponent<CanvasGroup>();
        //group.blocksRaycasts = false;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
        ////拖拽结束，销毁代替品
        //if (drag_icon)
        //{
        //    Destroy(drag_icon);
        //}
    }

    //public void OnDrop(PointerEventData eventData)
    //{
    //    //根据代替品的信息，改变当前对象的Sprite。
    //    var obj = eventData.pointerDrag;
    //    this.GetComponent<Image>().sprite = obj.GetComponent<Image>().sprite;
    //}
    private void SetDraggedPosition(PointerEventData eventData)
    {
        var rt = gameObject.GetComponent<RectTransform>();

        // transform the screen point to world point int rectangle
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
        }
    }
}
