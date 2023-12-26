using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class log : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("sceneChange", 1);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void sceneChange()
    {
        SceneManager.LoadScene("StageScene");
    }
}
