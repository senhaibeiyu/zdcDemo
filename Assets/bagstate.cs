using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagstate : MonoBehaviour {
    public GameObject bag;
    public bool Switch = false;
    //private Bag Bag;
    public static bagstate _instance;
    void Awake()
    {
        _instance = this; 
    }
    

   public void kaiguan()
    {
        if (Switch == false)
        {
            bag.gameObject.SetActive(true);
            //openbag();
            Switch = true;
        }
        else
        {
            bag.gameObject.SetActive(false);
            Switch = false;
            // closebag();
        }
    }
}
