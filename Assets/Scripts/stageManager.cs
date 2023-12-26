using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageManager : MonoBehaviour
    {

    public GameObject stageManagerObj;

    public int StageNumber;

    public bool clearSG1 = true;
    public bool clearSG2 = false;
    public bool clearSG3 = false;

    public float SG1Best = 0.00f;
    public float SG2Best = 0.00f;
    public float SG3Best = 0.00f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(stageManagerObj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void call()
    {
        SceneManager.LoadScene("StartScene");
    }
}
