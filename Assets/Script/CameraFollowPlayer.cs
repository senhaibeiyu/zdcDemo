using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;
    //  public Transform target;
    public float smoothing = 2;  //平滑N秒后到达
    public float distance = 0;
    public float rotatespeed = 1;
    Vector3 offsetPosition;
    public float scrollSpeed = 1;
    bool isRotate = false;
    public float skytime = 0;
    //  private Skybox sky;
    public Material[] changeskybox;
    private int index;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tag.player).transform;
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position;
        //   sky = GetComponent<Skybox>();

    }


    void Update()
    {

        transform.position = offsetPosition + player.position;
        RotateView();
        ScrollView();
        skytime += Time.deltaTime;
        if (skytime >= 5)
        {
            skytime = 0;

            RenderSettings.skybox = changeskybox[index];
            index++;
            if (index >= 5)
            {
                index = 0;
            }
        }
    }

    /// <summary>
    /// 镜头拉伸
    /// </summary>
    void ScrollView()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {

        }
        else
        {
            distance = offsetPosition.magnitude;
            distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            distance = Mathf.Clamp(distance, 7, 25);
            offsetPosition = offsetPosition.normalized * distance;

        }


    }

    /// <summary>
    /// 镜头旋转
    /// </summary>
    void RotateView()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {

        }
        else
        {
            if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
            {
                isRotate = true;
            }
            if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0))
            {
                isRotate = false;
            }
            if (isRotate)
            {
                transform.RotateAround(player.position, Vector3.up, rotatespeed * Input.GetAxis("Mouse X"));
                Vector3 originalPosition = transform.position;
                Quaternion originalRotation = transform.rotation;

                transform.RotateAround(player.position, transform.right, -rotatespeed * Input.GetAxis("Mouse Y"));
                float x = transform.eulerAngles.x;
                if (x < 10 || x > 80)
                {
                    transform.position = originalPosition;
                    transform.rotation = originalRotation;
                }
            }
            offsetPosition = transform.position - player.position;
        }

    }
}
