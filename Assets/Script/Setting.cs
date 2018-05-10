using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour {

    public static Setting instance;

    private bool SettingSwitch = false;
    public float toSpeed;
    public float goSpeed;

    void Awake()
    {
        instance = this;
    
    }

    void Update()
    {
       
        if (SettingSwitch == true)
        {
            this.transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0, 0, 0), toSpeed);
        }
        else
        {
            this.transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(550, 319, 0), goSpeed);
        }

    }



    public void Switch()
    {
        if (SettingSwitch == false)
        {
            SettingSwitch = true;
           
        }
        else
        {
            SettingSwitch = false;
                
        }

    }
    public void OnagainbuttonClick()
    {
        SceneManager.LoadScene("02_playgame");
    }

    public void OnmenubuttonClick()
    {
        SceneManager.LoadScene("01_start");
    }

    public void OnoverbuttonClick()
    {
        Application.Quit();
    }
}
