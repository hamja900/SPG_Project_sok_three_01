using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class log : MonoBehaviour
{
    void Start()
    {
        sceneChange();
    }

    void Update()
    {
 
    }

    void sceneChange()
    {
        LoadingSceneManager.LoadScene("StageScene");
    }
}
