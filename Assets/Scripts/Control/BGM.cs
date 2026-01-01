using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioSource msc;
    void Start()
    {
        msc=GetComponent<AudioSource>();
        msc.Play();
    }
    void Update()//3D模式中如果按下Esc则退出游戏
    {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
