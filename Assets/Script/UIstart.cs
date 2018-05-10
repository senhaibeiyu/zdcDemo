using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIstart : MonoBehaviour
{

    private Button btnSound;
    private AudioSource audioSourceBG;
    private Image imgSound;
    private Button btnPlay;
    public Sprite[] soundSprites;

    // Use this for initialization
    void Start()
    {
        getComponents();
        btnPlay.onClick.AddListener(onPlayClick);
        btnSound.onClick.AddListener(onSoundClick);
    }

    void OnDestroy() //销毁监听事件
    {
        btnPlay.onClick.RemoveListener(onPlayClick);

        btnSound.onClick.RemoveListener(onSoundClick);
    }

    private void getComponents() //寻找组件
    {
        btnPlay = transform.Find("btnPlay").GetComponent<Button>();
        btnSound = transform.Find("btnSound").GetComponent<Button>();
        audioSourceBG = transform.Find("btnSound").GetComponent<AudioSource>();
        imgSound = transform.Find("btnSound").GetComponent<Image>();
    }

    void onPlayClick() //场景转换
    {
        SceneManager.LoadScene("02_playgame");
    }

    void onSoundClick() //控制声音开关，并通过更换图标或颜色，来表现出来
    {
        if (audioSourceBG.isPlaying)
        {
            audioSourceBG.Pause();
            imgSound.sprite = soundSprites[1];
            //imgSound.color = Color.red;
        }
        else
        {
            audioSourceBG.Play();
            imgSound.sprite = soundSprites[0];
           // imgSound.color = Color.green;
        }
    }
}


