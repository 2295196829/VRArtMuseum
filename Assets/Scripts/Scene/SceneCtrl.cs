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
        Debug.Log($"OnSceneLoaded called for scene: {scene.name}"); // 确认是否执行

        if (scene.name == "SampleScene")
        {
            Debug.Log("Enter SampleScene section");
            mode_3D = GameObject.Find("3D");
            mode_VR = GameObject.Find("VR");

            Debug.Log($"mode_3D = {mode_3D}, mode_VR = {mode_VR}"); // 查看是否找到

            if (mode_3D == null || mode_VR == null)
            {
                Debug.LogError("物体未找到！");
                return;
            }
        // if (scene.name == "SampleScene")
        // {
        //     //查找对象
        //     mode_3D?.SetActive(true);
        //     mode_VR?.SetActive(true);
        //     mode_3D = GameObject.Find("3D");
        //     mode_VR = GameObject.Find("VR");
                        
        //     // 检测
        //     if (mode_3D == null || mode_VR == null)
        //     {
        //         Debug.LogError("未能找到3D或VR对象，请检查场景中的对象名称。");
        //         return;
        //     }

            //根据模式激活
            int modeVal = PlayerPrefs.GetInt("mode", 0);
            mode_3D.SetActive(PlayerPrefs.GetInt("mode") == 0);
            mode_VR.SetActive(PlayerPrefs.GetInt("mode") == 1);
        }
    }
    //ModeChoose场景中Button方法
    public void OnClick_3D()
    {
        PlayerPrefs.SetInt("mode", 0);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);

    }
    public void OnClick_VR()
    {
        PlayerPrefs.SetInt("mode", 1);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

    }
}

