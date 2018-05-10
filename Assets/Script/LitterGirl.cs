using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GirlState
{
    idle,
    walk,
    attack,
    death
}

public class LitterGirl : MonoBehaviour
{
    [SerializeField]
    [HideInInspector]
    public GirlState state = GirlState.idle;
    [SerializeField]
    [HideInInspector]
    public Animator anim;
    public float time = 8;
    public float timer = 0;
    public CharacterController characterController;
    public float speed = 1;

    [SerializeField]
    [HideInInspector]
    public float LGhp = 300;
    [SerializeField]
    [HideInInspector]
    public float LGCurrentHP = 300;
    [SerializeField]
    [HideInInspector]
    public int attack = 100;
    [SerializeField]
    [HideInInspector]
    public float smoothing = 3;
   
    public GameObject PopupDamage;
    private PlayerHealth playerhealth;
    [SerializeField]
    [HideInInspector]
    public int exp = 50;
    public Transform target;
    [SerializeField]
    [HideInInspector]
    public float MaxDistance = 10;
    [SerializeField]
    [HideInInspector]
    public float MinDistance = 3;
    public float attack_timer = 0; //进入攻击范围后的时间
    public float enemy_attack_time = 5; //一次攻击所需时间
    public float attack_speed = 1;
    public float enemy_attack_rate = 1f;
    public EnemySpawn spawn;
    private Transform player;
    public float distance;
    private SkillManager skillmanager;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        playerhealth = GameObject.FindGameObjectWithTag(Tag.player).GetComponent<PlayerHealth>();
        InvokeRepeating("add_enemy", 0, 1);
        player = GameObject.FindGameObjectWithTag(Tag.player).transform;
       
    }


    void Update()
    {
        timer += Time.deltaTime;
        EnemyAI();

        if (state == GirlState.death)
        {
            Debug.Log("1");
            anim.SetBool("param_idletodeath", true);
        }

        if (state == GirlState.idle)
        {
           
            anim.SetBool("walktoidle", true);
        }

        if (state == GirlState.walk)
        {
            
            anim.SetBool("param_idletowalk", true);
        }

        if (state == GirlState.attack)
        {
           
            
            attack_timer += Time.deltaTime;
            if (attack_timer >= enemy_attack_time)
            {
                anim.SetTrigger("girlattack");
                dam();
                attack_timer = 0;
            }
        }
    }

    void EnemyAI()
    {
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
         distance = Vector3.Distance(targetPos, transform.position);
        if (distance <= MaxDistance)
        {
            Debug.Log("进入追踪范围");
            if (distance <= MinDistance)
            {
                Debug.Log("开始攻击动画");
                StartCoroutine(autoattack());
            }
            else
            {
                
                state = GirlState.walk;
                transform.LookAt(targetPos);
                characterController.SimpleMove(transform.forward * speed);
            }
        }
        else
        {
          
            AnimatorStateInfo animinfo = anim.GetCurrentAnimatorStateInfo(0);

            ////判断当前播放动画名称，如果是walk，则向前行走
            if (timer > time)
            {
                
                timer = 0;
                judgeState();
            }
            if (animinfo.IsName("walk"))
            {
                characterController.SimpleMove(transform.forward * speed);
            }
        }
    }

    
    IEnumerator autoattack()
    {
        state = GirlState.attack;
        yield return new WaitForSeconds(0.0f);


    }

  

    void add_enemy()
    {

        attack += 1;
    }

    public void dam()
    {
        
        GameObject mObject = Instantiate(PopupDamage, transform.position, Quaternion.identity);
        mObject.GetComponent<attackText>().Value = playerhealth.attack + playerhealth.attack_add;
       
        Takedamage();
    }


    /// <summary>
    /// 判断状态
    /// </summary>
    void judgeState()
    {
        
        if (state == GirlState.idle || state == GirlState.walk)
        {
            RandomState();
        }


    }

    /// <summary>
    /// 随机数，控制敌人自动巡航
    /// </summary>
    void RandomState()
    {
        
        int value = Random.Range(0, 3);

        if (value == 0)
        {
            anim.SetBool("param_idletowalk", true);

        }
        else
        {
            anim.SetBool("walktoidle", true);
            transform.Rotate(transform.up * Random.Range(0, 360));
        }
    }

    /// <summary>
    /// 受伤后的事件
    /// </summary>
    public void Takedamage()
    {
        LGCurrentHP -= playerhealth.attack + playerhealth.attack_add;

        if (LGCurrentHP <= 0)
        {
            anim.SetBool("param_idletodeath", true);
            death();
        }
    }

    /// <summary>
    /// 死亡后的事件
    /// </summary>
    void death()
    {
        playerhealth.Getexp(70);
        playerhealth.getmoney(100);
        NPC.instance.OnEnemyDeath();
        EnemySpawn.instance.destroyEnemy();
        Destroy(this.gameObject, 2);
    }
}
