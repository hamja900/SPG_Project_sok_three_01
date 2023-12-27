using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;
    public AudioClip flip;  //박영진
    public AudioSource audioSource;  //박영진
    float cr = 193f;
    float cg = 236f;
    float cb = 228f;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isOpen", true);
        Invoke("wait", 0.4f);
        Invoke("startCard", 2.4f);
    }

    void Update()
    {
        cr += Time.deltaTime * 19.3f;
        cg += Time.deltaTime * 23.6f;
        cb += Time.deltaTime * 22.8f;

        if(cr > 193)
        {
            cr = 193;
        }
        if (cg > 236)
        {
            cg = 236;
        }
        if (cb > 228)
        {
            cb = 228;
        }

        transform.Find("cardBack").GetComponent<Renderer>().material.color = new Color(cr / 255f, cg / 255f, cb / 255f);
    }
  
    public void openCard()
    {
        cr = 0f;
        cg = 0f;
        cb = 0f;
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            GameManager.I.flipTime = 5.0f;
            GameManager.I.flipGaugeOn();
            audioSource.PlayOneShot(flip);  //박영진

            anim.SetBool("isOpen", true);
            Invoke("wait", 0.4f);  //카드 뒤집는 애니메이션이 진행되는 동안 cardFront의 등장을 늦춤

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
    } 
    void wait()
        {
         transform.Find("cardFront").gameObject.SetActive(true);
         transform.Find("cardBack").gameObject.SetActive(false);
         anim.SetBool("isFlipBack", false);
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
        anim.SetBool("isOpen", false);
        Invoke("waitBack", 0.4f);
    }

    void waitBack()
    {
        transform.Find("cardFront").gameObject.SetActive(false);
        transform.Find("cardBack").gameObject.SetActive(true);
        anim.SetBool("isFlipBack", true);
    }

    void startCard()
    {
        anim.SetBool("isOpen", false);
        Invoke("waitBack", 0.4f);
    }
}

