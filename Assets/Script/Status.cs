using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour {

    public static Status instance;

    private bool Show = false;
    public float toSpeed;
    public float goSpeed;

    private Text attacktext;
    private Text defendtext;
    private Text pointtext;
    private Text sumtext;

    private GameObject attackbuttonadd;
    private GameObject defendbuttonadd;

    private PlayerHealth playerhealth;

    void Awake()
    {
        instance = this;

        attacktext = transform.Find("attack").GetComponent<Text>();
        defendtext = transform.Find("defend").GetComponent<Text>();   
        pointtext = transform.Find("point").GetComponent<Text>();
        sumtext = transform.Find("sum").GetComponent<Text>();
        attackbuttonadd = transform.Find("attackbutton").gameObject;
        defendbuttonadd = transform.Find("defendbutton").gameObject;
        playerhealth = GameObject.FindGameObjectWithTag(Tag.player).GetComponent<PlayerHealth>();
    }

    /// <summary>
    /// 人物面板显示
    /// </summary>
    void Update()
    {
        if (Show == true)
        {
            this.transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(180, 20, 0), toSpeed);
        }
        else
        {
            this.transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(550, 20, 0), goSpeed);
        }

    }

    /// <summary>
    /// 开关
    /// </summary>
    public void SwithState()
    {
        if(Show == false)
        {
            Updateshow();
            Show = true;
        }
        else
        {
            Show = false;
        }
    }

    /// <summary>
    /// 将值传递至UI
    /// </summary>
    void Updateshow()
    {
        attacktext.text = playerhealth.attack + "+" + playerhealth.attack_add;
        defendtext.text = playerhealth.defend + "+" + playerhealth.defend_add;
      

        pointtext.text = playerhealth.point.ToString();

        sumtext.text = "伤害:" + (playerhealth.attack + playerhealth.attack_add)+ "\n"+ 
            "防御:" + (playerhealth.defend +  playerhealth.defend_add);

        if(playerhealth.point>0)
        {
            attackbuttonadd.SetActive(true);
            defendbuttonadd.SetActive(true);      
        }
        else
        {
            attackbuttonadd.SetActive(false);
            defendbuttonadd.SetActive(false);
        }
        
    }

    //传递属性点
    public void OnAttackbuttonClick()
    {
        bool addsuccess = playerhealth.GetPoint();
        if(addsuccess)
        {
            playerhealth.attack_add++;
            Updateshow();
        }
    }

    public void OnDefendbuttonClick()
    {
        bool addsuccess = playerhealth.GetPoint();
        if (addsuccess)
        {
            playerhealth.defend_add++;
            Updateshow();
        }
    }

}
