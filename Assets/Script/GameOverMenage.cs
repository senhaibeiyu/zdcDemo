using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenage : MonoBehaviour {

    public static GameOverMenage instance;
  
    private Animator anim;

    void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
    
    }

     void Update()
    {
        anim.SetTrigger("GameOver");
    }
   


}
