using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
     anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    public void openCard()
    {
        anim.SetBool("isOpen", true);
        Invoke("wait", 0.4f);//ī�� ������ �ִϸ��̼��� ����Ǵ� ���� cardFront�� ������ ����

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

    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false);
        Invoke("waitBack", 0.4f);
    }

    void waitBack()
    {
        transform.Find("cardFront").gameObject.SetActive(false);
        transform.Find("cardBack").gameObject.SetActive(true);
    }
}
