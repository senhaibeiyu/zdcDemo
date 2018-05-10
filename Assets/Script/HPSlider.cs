using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{

   
    private new Text name;
    public Slider hp;
    private PlayerHealth playerhealth;
    private Text hptext;

    /// <summary>
    /// 获取组件
    /// </summary>
    void Awake()
    {

        name = transform.Find("name").GetComponent<Text>();

        hp = transform.Find("HP").GetComponent<Slider>();

        hptext = transform.Find("HP/Fill Area/hpText").GetComponent<Text>();

    }

    void Start()
    {
        playerhealth = GameObject.FindGameObjectWithTag(Tag.player).GetComponent<PlayerHealth>();
        Update();
    }

    public void Update()
    {

        name.text = "等级 " + playerhealth.level + " " + playerhealth.name;
        hp.value = playerhealth.hp_current / playerhealth.hp * 1000;
        hptext.text = playerhealth.hp_current + " / " + playerhealth.hp;

    }
}
