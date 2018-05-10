using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SkillManager : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{

    public float skillCD = 2;
    public KeyCode keycode;
    public float timer = 0;
    private Image filledImage;
    public bool isStartTimer = false;
    private PlayerHealth playerhealth;
    private LitterGirl LGirl;
    private Animator anim;

   
    Transform skillintro1;
    Transform skillintro2;
    Transform skillintro3;

    void Awake()
    {
        skillintro1 = GameObject.Find("P1").transform;
        skillintro2 = GameObject.Find("P2").transform;
        skillintro3 = GameObject.Find("P3").transform;
       
    }
    void Start()
    {
        filledImage = transform.Find("SkillCD").GetComponent<Image>();
        playerhealth = GameObject.FindGameObjectWithTag(Tag.player).GetComponent<PlayerHealth>();
        LGirl = GameObject.FindGameObjectWithTag(Tag.enemy).GetComponent<LitterGirl>();
        anim = GameObject.FindGameObjectWithTag(Tag.player).GetComponent<Animator>();
     
    }

   
    void Update()
    {
        if (Input.GetKeyDown(keycode))
        {

            isStartTimer = true;
        }

        if (isStartTimer)
        {
            if (Input.GetKeyDown("1") && playerhealth.hp_current > 0 && timer == 0)
            {
                StartCoroutine(Attackanim());
            }
            if (Input.GetKeyDown("2") && playerhealth.hp_current > 0 && playerhealth.hp_current <= 9500 && timer == 0)
            {
                playerhealth.hp_current += 500;
            }
           
            if (Input.GetKeyDown("3") && timer == 0)
            {
                playerhealth.attack_add += 25;
            }
            timer += Time.deltaTime;
            filledImage.fillAmount = (skillCD - timer) / skillCD;

            if (timer >= skillCD)
            {
                filledImage.fillAmount = 0;
                timer = 0;
                isStartTimer = false;
            }
        }
    }

    IEnumerator Attackanim()
    {
       
        anim.SetTrigger("anytohit");
        EnemyHurt();
        yield return new WaitForSeconds(1);
        anim.SetTrigger("hittoidle");

    }

    void EnemyHurt()
    {
      
       
        if(LGirl.distance <= 3)
        {
            Debug.Log("3");
            LGirl.dam();
         
        }
    }

    public void OnClick()
    {
      
        isStartTimer = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.tag == "HPTAG"&& playerhealth.hp_current > 0 && playerhealth.hp_current <= 9500 && timer == 0)
        {
            playerhealth.hp_current += 500;
        }
        if (eventData.pointerCurrentRaycast.gameObject.tag == "addAttack"  && timer == 0)
        {
            playerhealth.attack_add += 25;
        }
        if (eventData.pointerCurrentRaycast.gameObject.tag == "attack" && timer == 0)
        {
            StartCoroutine(Attackanim());
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
        if (eventData.pointerCurrentRaycast.gameObject.tag == "attack")
        {
            
            skillintro1.localScale = new Vector3(1, 1, 1);
         
        }
        if (eventData.pointerCurrentRaycast.gameObject.tag == "HPTAG")
        {
           
            skillintro2.localScale = new Vector3(1, 1, 1);
        }
        if (eventData.pointerCurrentRaycast.gameObject.tag == "addAttack")
        {
            
            skillintro3.localScale = new Vector3(1, 1, 1);
        }
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      
        skillintro1.localScale = Vector3.zero;
        skillintro2.localScale = Vector3.zero;
        skillintro3.localScale = Vector3.zero;
    }
}
