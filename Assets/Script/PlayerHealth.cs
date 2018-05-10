using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState
{
    idle,
    running,
    attack,
    jump,
    death
}

public class PlayerHealth : MonoBehaviour
{
    public PlayerState state = PlayerState.idle;
    [SerializeField]
    public int level=1;
    [SerializeField]
    [HideInInspector]
    public float hp = 1000;  //血量
    [SerializeField]
    public float hp_current = 1000; //当前血量
    [SerializeField]
    [HideInInspector]
    public int exp = 0;
    [SerializeField]
    public new string name = "群星";
    [SerializeField]
    public int money = 1000; //金币数量
    [SerializeField]
    public int attack = 100;   //攻击力
    [SerializeField]
    public int attack_add = 0;
    [SerializeField]
    public int defend = 50; //防御
    [SerializeField]
    public int defend_add = 0;
    [SerializeField]
    [HideInInspector]
    public int point = 0; //属性点，剩余属性点数
    [SerializeField]
    [HideInInspector]
    public GameObject PopupDamage;
    [SerializeField]
    [HideInInspector]
    public Animator anim;
    private LitterGirl LG;

    public float timer = 0;
    public float timer_attack = 2;

    private PlayerMove playermove;
    [SerializeField]
    [HideInInspector]
    public GameObject gameover;
    [SerializeField]
    [HideInInspector]
    public GameObject restgame;

    void Start()
    {
        anim = GetComponent<Animator>();
        LG = GameObject.FindGameObjectWithTag(Tag.enemy).GetComponent<LitterGirl>();
        playermove = GetComponent<PlayerMove>();
        if (state == PlayerState.death)
        {
            anim.SetBool("param_idletodeath", true);
        }

        if (state == PlayerState.jump)
        {
            anim.SetBool("param_idletojump", true);
        }
        if (state == PlayerState.running)
        {
            anim.SetBool("param_idletorunning", true);

        }
        else if (state == PlayerState.attack)
        {
            anim.SetBool("runningtoattack", true);
        }
    }

    void Update()
    {
        

    }

   /// <summary>
   /// 重新开始
   /// </summary>
    void Restgame()
    {
        restgame.gameObject.SetActive(true);
    }

    /// <summary>
    /// 游戏结束返回主菜单
    /// </summary>
    void Gameover()
    {
        gameover.gameObject.SetActive(true);
       
    }

    /// <summary>
    /// 获取金钱
    /// </summary>
    /// <param name="count"></param>
    public void getmoney(int count)
    {
        money += count;
    }

    /// <summary>
    /// 玩家属性点
    /// </summary>
    /// <param name="Point"></param>
    /// <returns></returns>
    public bool GetPoint(int Point = 1) //Point=1
    {
        if (point >= Point)
        {
            point -= Point;
            return true;
        }
        return false;
    }


    /// <summary>
    /// 获得经验，升级，设置升级所需经验值
    /// </summary>
    /// <param name="exp"></param>
    public void Getexp(int exp)
    {
        this.exp += exp;
        int levelup_exp = level * 100;
        while (this.exp >= levelup_exp)
        {
            this.level++;
            point += 5;
            this.exp -= levelup_exp;
            levelup_exp = level * 100;
        }
    }

    /// <summary>
    /// 碰撞事件
    /// </summary>
    /// <param name="mCollider"></param>
    void OnTriggerEnter(Collider mCollider)
    {
        if (mCollider.gameObject.tag == "Enemy")
        {

            //克隆伤害弹出组件  
            GameObject mObject = Instantiate(PopupDamage, transform.position, Quaternion.identity);

            int dam;

            dam = LG.attack - defend - defend_add;

            //使用if语句进行伤害显示，当敌人攻击力低于玩家防御时，强制扣除1点，避免受伤为负
            if (dam > 0)
            {
                mObject.GetComponent<attackText>().Value = LG.attack - defend - defend_add;
            }
            else
            {
                mObject.GetComponent<attackText>().Value = 1;
            }
            //anim.SetBool("anytoattack", true);  //失效 ~~\(ㄒoㄒ)/~~
            Takedamage();

        }
    }


    /// <summary>
    /// 玩家受伤后
    /// </summary>
    public void Takedamage()
    {
        anim.SetBool("anytoattack", false);

        if (LG.attack - defend - defend_add > 0)
        {
            hp_current -= LG.attack - defend - defend_add;

        }
        else

        {
            hp_current -= 1;
        }


        if (hp_current <= 0)
        {
            InvokeRepeating("Gameover", 3f, 99999f);
            InvokeRepeating("Restgame", 5f, 99999f);

            LG.state = GirlState.idle;
            death();
        }

    }

    /// <summary>
    /// 玩家死亡后
    /// </summary>
    void death()
    {
        anim.SetBool("param_idletodeath", true);
        playermove.enabled = false;
        //LG.characterController.enabled = false;
        //Destroy(this.gameObject, 2);

    }
}
