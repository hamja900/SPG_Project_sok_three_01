using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject matchTxt;//퇴근텍스트 가져오기용
    public Text timeTxt;
    public GameObject endTxt;
    public AudioSource audioSource;
    public AudioClip match;
    public AudioClip fail;
    public Image flipG;
    public float flipTime;
    public float time = 30f;
    GameObject stageNumObject;
    int stage;

    void Awake()
    {
        I = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

        stageNumObject = GameObject.Find("stageManager");
        stage = stageNumObject.GetComponent<stageManager>().StageNumber;

        if (stage == 1)//이지모드 12장 랜덤 뿌리기
        {
            int[] cards = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
            cards = cards.OrderBy(item => Random.Range(-1f, 1f)).ToArray();

            matchTxt = GameObject.Find("Canvas/matchTxt");


            for (int i = 0; i < 12; i++)
            {


                GameObject newCard = Instantiate(card);
                newCard.transform.parent = GameObject.Find("cards").transform;

                float x = (i / 4) * 1.1f - 1.2f;
                float y = (i % 4) * 1.1f - 4.0f;
                newCard.transform.position = new Vector3(x, y, 0);

                string cardName = cards[i].ToString();
                newCard.transform.Find("cardFront").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(cardName);
            }
        }
        else if (stage == 2)//하드모드 16장 랜덤 뿌리기
        {
            int[] cards = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7};
            cards = cards.OrderBy(item => Random.Range(-1f, 1f)).ToArray();

            matchTxt = GameObject.Find("Canvas/matchTxt");


            for (int i = 0; i < 16; i++)
            {


                GameObject newCard = Instantiate(card);
                newCard.transform.parent = GameObject.Find("cards").transform;

                float x = (i / 4) * 1.1f - 1.7f;
                float y = (i % 4) * 1.1f - 4.2f;
                newCard.transform.position = new Vector3(x, y, 0);

                string cardName = cards[i].ToString();
                newCard.transform.Find("cardFront").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(cardName);
            }
        }
        else if (stage == 3)//헬모드 24장 랜덤뿌리기
        {
            int[] cards = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12};
            cards = cards.OrderBy(item => Random.Range(-1f, 1f)).ToArray();

            matchTxt = GameObject.Find("Canvas/matchTxt");


            for (int i = 0; i < 24; i++)
            {


                GameObject newCard = Instantiate(card);
                newCard.transform.parent = GameObject.Find("cards").transform;

                float y = (i / 4) * 1.1f - 4.4f;
                float x = (i % 4) * 1.1f - 1.7f;
                newCard.transform.position = new Vector3(x, y, 0);

                string cardName = cards[i].ToString();
                newCard.transform.Find("cardFront").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(cardName);
            }
        }
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        flipTime -= Time.deltaTime;

        int cardsLeft = GameObject.Find("cards").transform.childCount;

        if (time <= 0 || cardsLeft == 0)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;

            if(stage == 1)
            {
                GameObject.Find("stageManager").GetComponent<stageManager>().clearSG2 = true;
            } else if (stage == 2)
            {
                GameObject.Find("stageManager").GetComponent<stageManager>().clearSG3 = true;
            } 
        }

        if (time < 10 && timeTxt.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("timeTxt_idle"))
        {
            timeTxt.GetComponent<Animator>().SetTrigger("isTime");
        }
        if (time < 5 && timeTxt.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("timeTxt_1"))
        {
            timeTxt.GetComponent<Animator>().SetTrigger("isTime");
        }

        if (flipTime <= 0)
        {
            flipTimeOver();
            flipGaugeOff();
        }
        timeTxt.color = new Color(1, time * 8.5f / 255, time * 8.5f / 255, 1);
        flipG.transform.localScale = new Vector3(flipTime * 0.2f, 1, 1);
        flipG.color = new Color(1, flipTime * 51 / 255f, flipTime * 51 / 255f, 1);
    }

    public void isMatched()
    {
        
        flipGaugeOff();
        string firstCardImage = firstCard.transform.Find("cardFront").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("cardFront").GetComponent<SpriteRenderer>().sprite.name;

            matchTxt.transform.Find("0").gameObject.SetActive(false);
            matchTxt.transform.Find("1").gameObject.SetActive(false);
            matchTxt.transform.Find ("2").gameObject.SetActive(false);
            matchTxt.transform.Find("3").gameObject.SetActive(false);
            matchTxt.transform.Find("4").gameObject.SetActive(false);
            matchTxt.transform.Find("5").gameObject.SetActive(false);
            matchTxt.transform.Find("Fail").gameObject.SetActive(false);

        if (firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);

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
            audioSource.PlayOneShot(fail);
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
    void flipTimeOver()
    {
        if (firstCard != null)
        {
            firstCard.GetComponent<card>().closeCardInvoke();
            firstCard = null;
        }
    }

    public void flipGaugeOn()
    {
        flipG.transform.gameObject.SetActive(true);
    }
    void flipGaugeOff()
    {
        flipG.transform.gameObject.SetActive(false);
    }
    //퇴근메시지도 퇴근시키기 위한 노력 끝
    //연습
    //연습2
    //연습3
    //연습4
    //연습5
    //연습6
    //연습7
    //연습8
}
