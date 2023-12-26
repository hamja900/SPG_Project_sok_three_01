using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject matchTxt;//����ؽ�Ʈ ���������

   
     void Awake()
    {
        I = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        int[] cards = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
            cards = cards.OrderBy(item => Random.Range(-1f, 1f)).ToArray();

        matchTxt = GameObject.Find("Canvas/matchTxt");


        for (int i = 0; i < 16; i++)
        {
            

            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x , y, 0);

            string cardName = cards[i].ToString();
            newCard.transform.Find("cardFront").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(cardName);
        }
        // Update is called once per frame
    }
       
    void Update()
        {

        }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("cardFront").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("cardFront").GetComponent<SpriteRenderer>().sprite.name;


        if (firstCardImage == secondCardImage)
        {
             
            switch (int.Parse(firstCardImage))//��ٷ���
            {
               
                case 0:
                case 1:
                    matchTxt.transform.Find("0").gameObject.SetActive(true);
                    Invoke("waitMatchTxt0", 2f);
                    break; //������            
                case 2:
                case 3:
                    matchTxt.transform.Find("1").gameObject.SetActive(true);
                    Invoke("waitMatchTxt1", 2f);
                    break; //����ȣ
                case 4:
                case 5:
                    matchTxt.transform.Find("2").gameObject.SetActive(true);
                    Invoke("waitMatchTxt2", 2f);
                    break; //���λ�
                case 6:
                case 7:
                    matchTxt.transform.Find("3").gameObject.SetActive(true);
                    Invoke("waitMatchTxt3", 2f);
                    break; //������
                case 8:
                case 9:
                    matchTxt.transform.Find("4").gameObject.SetActive(true);
                    Invoke("waitMatchTxt4", 2f);
                    break; //�ڿ���
                case 10:
                case 11:
                    matchTxt.transform.Find("5").gameObject.SetActive(true);
                    Invoke("waitMatchTxt5", 2f);
                    break; //�ǹ��� �л�


            }


            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

           
        }
        else
        {
            matchTxt.transform.Find("Fail").gameObject.SetActive(true);
            Invoke("waitMatchTxt", 2f);


            firstCard.GetComponent <card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }

        firstCard = null;
        secondCard = null;
    }

    
    void waitMatchTxt0()//��ٸ޽����� ��ٽ�Ű�� ���� ��� ����
    {
        matchTxt.transform.Find("0").gameObject.SetActive(false);
    }
    void waitMatchTxt1()
    {
        matchTxt.transform.Find("1").gameObject.SetActive(false);
    }
    void waitMatchTxt2()
    {
        matchTxt.transform.Find("2").gameObject.SetActive(false);
    }
    void waitMatchTxt3()
    {
        matchTxt.transform.Find("3").gameObject.SetActive(false);
    }
    void waitMatchTxt4()
    {
        matchTxt.transform.Find("4").gameObject.SetActive(false);
    }
    void waitMatchTxt5()
    {
        matchTxt.transform.Find("5").gameObject.SetActive(false);
    }
    void waitMatchTxt()
    {
        matchTxt.transform.Find("Fail").gameObject.SetActive(false);
    }
    //��ٸ޽����� ��ٽ�Ű�� ���� ��� ��
    //����
    //����2
    //����3
    //����4
    //����5
    //����6
    //����7
}
