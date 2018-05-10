using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ConsumablesManager : MonoBehaviour,IPointerDownHandler {

    GameObject item;
    Text index;
    int indexInt = 0;
    public float Speed = 2000;
    string indexstr = "";
    private GameObject storage;
    GameObject bi;
    public void OnPointerDown(PointerEventData eventData)
    {
       if(Input.GetMouseButtonDown(1))
        {
            index = transform.GetChild(0).GetComponent<Text>();
            indexInt = int.Parse(index.text);
            if(indexInt!=1)
            {
                indexInt -= 1;
                indexstr = indexInt.ToString();
                index.text = indexstr;
            }
            else
            {
                item = eventData.pointerCurrentRaycast.gameObject;
                ItemInfo.DeleteItem(item.transform.parent.name);
                StartCoroutine(ReturnPool());
                item.transform.SetParent(storage.transform);
            }
        }
    }

    // Use this for initialization
    void Start () {
        storage = GameObject.Find("Bag/Toggroup/storage").gameObject;
        bi = GameObject.Find("BagInfo").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ReturnPool()
    {
        bi.transform.localPosition = Vector3.MoveTowards(bi.transform.localPosition, new Vector3(-532, -7, 0), Speed);
        yield return new WaitForSeconds(0.0f);
        Objectpool.Return(item);
    }
}
