using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baginfoManager : MonoBehaviour
{
    private bool ShopSwitch = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float timer=0;
        timer += Time.deltaTime;

        Debug.Log(timer);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.SetActive(false);
        }
    }
   public  void Switch()
    {
        Debug.Log("是否执行到这步");
        if (ShopSwitch == false)
        {
            Debug.Log("打开开关");
            ShopSwitch = true;
           
            gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("关闭开关");
            ShopSwitch = false;
            gameObject.SetActive(false);
        }

    }
}
