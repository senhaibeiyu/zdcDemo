using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    public static NPC instance;
    public GameObject questshow;
    public bool intask = false;

    public int killnumber = 0;

    public Text deslaber;

    public GameObject btnaccept;
    public GameObject btncancel;
    public GameObject btnok;

    private PlayerHealth health;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        health = GameObject.FindGameObjectWithTag(Tag.player).GetComponent<PlayerHealth>();
    }

    //当鼠标位于collider上，每一帧调用这个方法
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
          

        }
        else
        {
            if (Input.GetMouseButtonDown(0))//点击NPC
            {
                GetComponent<AudioSource>().Play();
                //audio.play();
                if (intask)
                {
                    showtaskprogress();
                }
                else
                {
                    showtaskdes();
                }
                quest();
            }
        

        }

      
    }
    void quest()
    {
        questshow.gameObject.SetActive(true);
        //questshow.enabled = true;

    }

    void showtaskdes()//显示人物描述
    {
        deslaber.text = "未接任务：\n打倒两个敌人\n奖励：\n1000金币  50经验值";
        btnok.SetActive(false);
        btnaccept.SetActive(true);
        btncancel.SetActive(true);
    }

    void showtaskprogress() //显示人物进度
    {
        deslaber.text = "已接任务：\n你已经打倒了" + killnumber + "个敌人";
        btnok.SetActive(true);
        btnaccept.SetActive(false);
        btncancel.SetActive(false);
    }

    public void OnEnemyDeath()
    {
        if (intask)
            killnumber++;
    }
    public void OnAcceptButtonClick()
    {
        showtaskprogress();
        intask = true;//表示在任务中

    }

    public void OnOkButtonClick()
    {

        if (killnumber >= 2)
        {
            //完成任务
            health.getmoney(1000);
            health.Getexp(50);
            killnumber = 0;
            showtaskdes();
        }

        else
        {
            //没有完成任务
            closequest();
        }
    }

    public void OnCancelButtonClick()
    {
        closequest();
    }

    void closequest()
    {

        questshow.gameObject.SetActive(false);
    }

    public void OnCloseButtonClick() //点击关闭按钮
    {
        closequest();

    }


}
