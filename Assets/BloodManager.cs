using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodManager : MonoBehaviour
{

   
    public  Slider Enemyhp;
    private LitterGirl Litterhealth;
    private  Text hptext;
    void Awake()
    {
        Enemyhp = GetComponent<Slider>();
        hptext = transform.Find("EnemyInfo/EnemyHp").GetComponent<Text>();

    }
   
    void Start()
    {

        Litterhealth = transform.parent.gameObject.transform.parent.gameObject.GetComponent<LitterGirl>();
        
    }

  
    void Update()
    {
        
        Enemyhp.value = Litterhealth.LGCurrentHP / Litterhealth.LGhp * 100;
    
        hptext.text = Litterhealth.LGCurrentHP + " / " + Litterhealth.LGhp;
      
    }
}
