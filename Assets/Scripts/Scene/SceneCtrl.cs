using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour
{
    private GameObject mode_3D;
    private GameObject mode_VR;

    //Origin场景中Button方法
    public void OnClick_Enter()
    {
        SceneManager.LoadScene("ModeChoose");
    }
    public void OnClick_Exit()
    {
        Application.Quit();
    }

    //SampleScene场景加载完毕调用方法
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleScene")
        {
            //全部激活才能获取到物件
            mode_3D?.SetActive(true);
            mode_VR?.SetActive(true);
            mode_3D = GameObject.Find("3D");
            mode_VR = GameObject.Find("VR");
            //根据模式调整激活与否
            mode_3D.SetActive(PlayerPrefs.GetInt("mode") == 0);
            mode_VR.SetActive(PlayerPrefs.GetInt("mode") == 1);
        }
    }
    //ModeChoose场景中Button方法
    public void OnClick_3D()
    {
        PlayerPrefs.SetInt("mode", 0);
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void OnClick_VR()
    {
        PlayerPrefs.SetInt("mode", 1);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
}

