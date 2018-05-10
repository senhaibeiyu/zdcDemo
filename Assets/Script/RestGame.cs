using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestGame : MonoBehaviour
{

    public static RestGame instance;
    
    void Awake()
    {
        instance = this;
      
    }

    public void Update()
    {
        startgame();

    }

    /// <summary>
    /// 重新开始游戏
    /// </summary>
    void startgame()
    {
        this.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("02_playgame");
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("01_start");
        }
    }

}
