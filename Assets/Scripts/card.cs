using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;
    public AudioClip flip;//박영진
    public AudioSource audioSource;//박영진
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isOpen", true);
        Invoke("wait", 0.4f);
        Invoke("startCard", 2.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    public void openCard()
    {
        GameManager.I.flipTime = 5.0f;
        GameManager.I.flipGaugeOn();
        audioSource.PlayOneShot(flip);//박영진

        anim.SetBool("isOpen", true);
        Invoke("wait", 0.4f);//카드 뒤집는 애니메이션이 진행되는 동안 cardFront의 등장을 늦춤

        if (GameManager.I.firstCard == null)
        {
            GameManager.I.firstCard = gameObject;
        }
        else
        {
            GameManager.I.secondCard = gameObject;
            GameManager.I.isMatched();
        }

    } 
    void wait()
        {
         transform.Find("cardFront").gameObject.SetActive(true);
         transform.Find("cardBack").gameObject.SetActive(false);
        }

    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 1.0f);
    }
    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void closeCard()
    {
        Invoke("closeCardInvoke", 1.0f);
    }

    public void closeCardInvoke()
    {
        transform.Find("cardBack").GetComponent<Renderer>().material.color = new Color(100 / 255f, 100 / 255f, 100 / 255f);
        anim.SetBool("isOpen", false);
        Invoke("waitBack", 0.4f);
    }

    void waitBack()
    {
        transform.Find("cardFront").gameObject.SetActive(false);
        transform.Find("cardBack").gameObject.SetActive(true);
    }

    void startCard()
    {
        anim.SetBool("isOpen", false);
        Invoke("waitBack", 0.4f);
    }
}

