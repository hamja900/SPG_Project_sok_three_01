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
    public GameObject matchTxt;//퇴근텍스트 가져오기용

   
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
             
            switch (int.Parse(firstCardImage))//퇴근로직
            {
               
                case 0:
                case 1:
                    matchTxt.transform.Find("0").gameObject.SetActive(true);
                    Invoke("waitMatchTxt0", 2f);
                    break; //이혜미            
                case 2:
                case 3:
                    matchTxt.transform.Find("1").gameObject.SetActive(true);
                    Invoke("waitMatchTxt1", 2f);
                    break; //박태호
                case 4:
                case 5:
                    matchTxt.transform.Find("2").gameObject.SetActive(true);
                    Invoke("waitMatchTxt2", 2f);
                    break; //조민상
                case 6:
                case 7:
                    matchTxt.transform.Find("3").gameObject.SetActive(true);
                    Invoke("waitMatchTxt3", 2f);
                    break; //석동구
                case 8:
                case 9:
                    matchTxt.transform.Find("4").gameObject.SetActive(true);
                    Invoke("waitMatchTxt4", 2f);
                    break; //박영진
                case 10:
                case 11:
                    matchTxt.transform.Find("5").gameObject.SetActive(true);
                    Invoke("waitMatchTxt5", 2f);
                    break; //의문의 학생


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

    
    void waitMatchTxt0()//퇴근메시지도 퇴근시키기 위한 노력 시작
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
    //퇴근메시지도 퇴근시키기 위한 노력 끝
    //연습
    //연습2
    //연습3
    //연습4
    //연습5
    //연습6
    //연습7
}
