using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public float Spawntime = 5f;
    private float timer = 0;
    private int Currentnumber = 0;
    public int Maxnumber = 4;
    public GameObject littergirl;
    public static EnemySpawn instance;

    void Awake()
    {
        instance = this;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (Currentnumber < Maxnumber)
        {
            if (timer >= Spawntime)
            {
                Vector3 position = transform.position;
                position.x += Random.Range(-4, 4);
                position.z += Random.Range(-4, 4);

                GameObject go = GameObject.Instantiate(littergirl, position, Quaternion.identity) as GameObject;
                go.GetComponent<LitterGirl>().spawn = this;
                timer = 0;
                Currentnumber++;
            }
        }
    }
  public  void destroyEnemy()
    {
        Currentnumber--;
    }


}
