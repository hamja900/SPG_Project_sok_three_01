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

    }

    void Update()
    {
            if (credits.transform.position.y >= 9700.0f)
            {
                SceneManager.LoadScene("StageScene");
            }
            else
            {
                credits.transform.position += new Vector3(0, speed, 0);
            }
    }
    public void skips()
    {
        SceneManager.LoadScene("StageScene");
    }
}
