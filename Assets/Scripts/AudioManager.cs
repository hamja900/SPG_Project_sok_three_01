using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bgmusic;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = bgmusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.I.time < 10)
        {
            audioSource.pitch = 1.2f;
        }
        if (GameManager.I.time < 5)
        {
            audioSource.pitch = 1.4f;
        }
    }
}
