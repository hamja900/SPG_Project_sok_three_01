using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minusTxt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyTxt", 1f);
    }
    void DestroyTxt()
    {
        Destroy(gameObject);
    }
}
