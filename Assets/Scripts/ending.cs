using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    float speed = 0.3f;
    bool ok = false;
    public GameObject credits;

    void Start()
    {
        Invoke("StartEding", 2.0f);
        Debug.Log("����");
    }

    // Update is called once per frame
    void Update()
    {
        if (ok)
        {
            if (credits.transform.position.y >= 9700.0f)
            {
                SceneManager.LoadScene("StageScene");
                Debug.Log("��ũ��");
            }
            else
            {
                credits.transform.position += new Vector3(0, speed, 0);
                Debug.Log("��");
            }
        }
    }

    void StartEding()
    {
        ok = true; ; 
        Debug.Log("�Լ�");
    }
    public void skips()
    {
        SceneManager.LoadScene("StageScene");
    }
}
