using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class log : MonoBehaviour
{
    void Start()
    {
        Invoke("sceneChange", 2);
    }

    void Update()
    {
 
    }

    void sceneChange()
    {
        SceneManager.LoadScene("StageScene");
    }
}
