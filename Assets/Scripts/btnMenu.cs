using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class btnMenu : MonoBehaviour
{
    public GameObject stage;
    public stageManager sm;

    public GameObject button1;
    public GameObject button2;

    public GameObject sgText;
    void Start()
    {
        stage = GameObject.Find("stageManager");

        if (stage.GetComponent<stageManager>().clearSG2 == true)
        {
            button1.GetComponent<Image>().color = new Color(255 / 255f, 208 / 255f, 208 / 255f);
        }
        if (stage.GetComponent<stageManager>().clearSG3 == true)
        {
            button2.GetComponent<Image>().color = new Color(255 / 255f, 208 / 255f, 208 / 255f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stageEasy()
    {
        if (stage.GetComponent<stageManager>().clearSG1 == true)
        {
            stage.GetComponent<stageManager>().StageNumber = 1;
            stage.GetComponent<stageManager>().call();
        }
    }
    public void stageHard()
    {
        if (stage.GetComponent<stageManager>().clearSG2 == true)
        {
            stage.GetComponent<stageManager>().StageNumber = 2;
            stage.GetComponent<stageManager>().call();
        }
        else
        {
            sgText.SetActive(true);
            Invoke("sgTextClose", 2.0f);
        }
    }
    public void stageHell()
    {
        if (stage.GetComponent<stageManager>().clearSG3 == true)
        {
            stage.GetComponent<stageManager>().StageNumber = 3;
            stage.GetComponent<stageManager>().call();
        }
        else
        {
            sgText.SetActive(true);
            Invoke("sgTextClose", 2.0f);
        }
    }

    void sgTextClose()
    {
        sgText.SetActive(false);
    }

}
