using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 10f;
    public float jumpspeed = 5f;

    public GameObject Effect;
    Vector3 targetposition = Vector3.zero;
    private Animator anim;
    private int groundLayerIndex = -1; //地面层
                                       // private bool isWall = false;
    private bool isGround = false;
  

    void Start()
    {
        anim = this.GetComponent<Animator>();
        groundLayerIndex = LayerMask.GetMask("Ground");

    }   

    
    void Update()
    {
        Vector3 velocity = GetComponent<Rigidbody>().velocity;

        //玩家移动
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * z * speed * Time.deltaTime);//W S 上 下
        transform.Translate(Vector3.right * x * speed * Time.deltaTime);//A D 左右

      

        //判断玩家是否在地面,是则跳起来
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpspeed;
            GetComponent<Rigidbody>().velocity = velocity;
        }
        anim.SetFloat("param_idletojump", GetComponent<Rigidbody>().velocity.y);

        //得到射线信息


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        //点击鼠标
        //if(Input.GetButtonDown("Fire1"))
        //{
        //    bool isCollider = Physics.Raycast(ray, out hitInfo);

        //    if (isCollider && hitInfo.collider.tag == Tag.ground)
        //    {
        //        mouseEffect(hitInfo.point);  //点击触发特效
        //        LookAtTarget(hitInfo.point);  //点击使人物朝向
        //    }
        //}

        //控制动画
        if (x != 0 || z != 0)
        {
            anim.SetBool("param_idletorunning", true);
        }

        else
        {
            anim.SetBool("param_idletorunning", false);
        }

        //控制人物面向，跟随鼠标位置
        if(Input.GetMouseButton(1))
        {
            if (Physics.Raycast(ray, out hitInfo, 600, groundLayerIndex))
            {

                Vector3 target = hitInfo.point;

                target.y = transform.position.y;

                transform.LookAt(target);

            }
        }
       
    }

    //获得人物面向
    void LookAtTarget(Vector3 hitpoint)
    {
        targetposition = hitpoint;
        targetposition = new Vector3(targetposition.x, transform.position.y, targetposition.z);
        this.transform.LookAt(targetposition);
    }

    //实例化点击鼠标后的特效
    void mouseEffect(Vector3 hitpoint)
    {
        hitpoint = new Vector3(hitpoint.x, hitpoint.y + 0.1f, hitpoint.z );

        Object.Instantiate(Effect, hitpoint, Quaternion.identity);
    }

    //检测是否与地面碰撞
    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Ground")
        {
            isGround = true;
        }

    }

    public void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "Ground")
        {
            isGround = false;
        }

    }
}
