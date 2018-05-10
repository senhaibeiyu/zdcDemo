using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ExpSlider : MonoBehaviour
{

    public static ExpSlider instance;

    private PlayerHealth playerhealth;

    private Text expnumber;

    public Slider expSlider;
    private Text exppercent;

    void Awake()
    {
        instance = this;
        expnumber = transform.Find("expnumber").GetComponent<Text>();

        exppercent = transform.Find("Fill Area/Fill/exppercent").GetComponent<Text>();

        expSlider = GetComponent<Slider>();
    }

    void Start()
    {
        playerhealth = GameObject.FindGameObjectWithTag(Tag.player).GetComponent<PlayerHealth>();

        Update();
    }

    /// <summary>
    /// EXP
    /// </summary>
    public void Update()
    {
       
        expnumber.text = playerhealth.exp + " / " + playerhealth.level * 100;

        expSlider.value = playerhealth.exp / playerhealth.level * 10;

        exppercent.text = expSlider.value/10 + "%";


    }



}
