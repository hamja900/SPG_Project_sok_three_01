using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject matchTxt;//����ؽ�Ʈ ���������
    public Text timeTxt;
    public GameObject end; // �˾�â
    public GameObject die; // �˾�â
    public Text countText; //�õ�Ƚ��
    public Text endTime;
    public Text bestTime;
    public Text bestTimeTxet;

    public float bestScore;
    public float newScore;

    public AudioSource audioSource;
    public AudioClip match;
    public AudioClip fail;
    public Image flipG;
    public float flipTime;
    public float time = 60f;
    public float matchTxtTime;
    public float timeLimit; // �ð� ����
    private float currentTime;
    GameObject stageNumObject;
    int stage;
    int count = 0;
    public GameObject minusTxt;

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        Time.timeScale = 1.0f;

        matchTxtTime = 2f;

        stageNumObject = GameObject.Find("stageManager");
        stage = stageNumObject.GetComponent<stageManager>().StageNumber;
        string bestTxt;

        if (stage == 1) {
            bestTxt = GameObject.Find("stageManager").GetComponent<stageManager>().SG1Best.ToString("N2");
            bestTimeTxet.text = "Best : " + bestTxt;
         } else if (stage == 2)
        {
            bestTxt = GameObject.Find("stageManager").GetComponent<stageManager>().SG2Best.ToString("N2");
            bestTimeTxet.text = "Best : " + bestTxt;
        } else if (stage == 3)
        {
            bestTxt = GameObject.Find("stageManager").GetComponent<stageManager>().SG3Best.ToString("N2");
            bestTimeTxet.text = "Best : " + bestTxt;
        }

        if (stage == 1)//������� 12�� ���� �Ѹ���
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
        else if (stage == 2)//�ϵ��� 16�� ���� �Ѹ���
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
        else if (stage == 3)//���� 24�� �����Ѹ���

        {
            int[] cards = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11};
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
        matchTxtTime -= Time.deltaTime;

        if (matchTxtTime <= 0)
        {
            matchTxtOff();
        }

        int cardsLeft = GameObject.Find("cards").transform.childCount;

        if (time <= 0) //�ð��� ��
        {
            die.SetActive(true);
            Time.timeScale = 0.0f;

        } else if (cardsLeft == 0) //ī�� ��
        {
            endTime.text = time.ToString("N2");
            newScore = time;
            if(bestScore < newScore)
            {
                bestScore = newScore;
                bestTime.text = "Best : " + (time.ToString("N2"));
                if (stage == 1)
                {
                    GameObject.Find("stageManager").GetComponent<stageManager>().SG1Best = bestScore;
                }  else if (stage == 2) {
                    GameObject.Find("stageManager").GetComponent<stageManager>().SG2Best = bestScore;
                } else if (stage == 3) {
                    GameObject.Find("stageManager").GetComponent<stageManager>().SG3Best = bestScore;
                }
            }
            end.SetActive(true); //�˾�â
            Time.timeScale = 0.0f;

            if (stage == 1)
            {
                GameObject.Find("stageManager").GetComponent<stageManager>().clearSG2 = true;
            }
            else if (stage == 2)
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


    private void TimeDeduction()
    {
        throw new System.NotImplementedException();
    }

    public void isMatched()
    {
        flipGaugeOff();
        string firstCardImage = firstCard.transform.Find("cardFront").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("cardFront").GetComponent<SpriteRenderer>().sprite.name;

        matchTxtTime = 2f;

        matchTxtOff();

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

            switch (int.Parse(firstCardImage))//��ٷ���
            {

                case 0:
                case 1:
                    matchTxtOn_0();
                    break; //������            
                case 2:
                case 3:
                    matchTxtOn_1();
                    break; //����ȣ
                case 4:
                case 5:
                    matchTxtOn_2();
                    break; //���λ�
                case 6:
                case 7:
                    matchTxtOn_3();
                    break; //������
                case 8:
                case 9:
                    matchTxtOn_4();
                    break; //�ڿ���
                case 10:
                case 11:
                    matchTxtOn_5();
                    break; //�ǹ��� �л�


            }

            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();
        }
        else
        {
            GameObject timeM = Instantiate(minusTxt);
            timeM.transform.parent = GameObject.Find("Canvas").transform;
            matchTxtOn_Fail();
            firstCard.GetComponent <card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
            audioSource.PlayOneShot(fail);
            time -= 3.0f;       // �ð� ���� 
            currentTime -= 3.0f;
        }

        firstCard = null;
        secondCard = null;

        count += 1;
        countText.text = "�õ� Ƚ�� : " + count.ToString();

    }

    public void matchTxtOn_0() //��ٸ޼�����
    {
        matchTxt.transform.Find("0").gameObject.SetActive(true);
    }
    public void matchTxtOn_1()
    {
        matchTxt.transform.Find("1").gameObject.SetActive(true);
    }
    public void matchTxtOn_2()
    {
        matchTxt.transform.Find("2").gameObject.SetActive(true);
    }
    public void matchTxtOn_3()
    {
        matchTxt.transform.Find("3").gameObject.SetActive(true);
    }
    public void matchTxtOn_4()
    {
        matchTxt.transform.Find("4").gameObject.SetActive(true);
    }
    public void matchTxtOn_5()
    {
        matchTxt.transform.Find("5").gameObject.SetActive(true);
    }
    public void matchTxtOn_Fail()
    {
        matchTxt.transform.Find("Fail").gameObject.SetActive(true);
    }
    public void matchTxtOff()
    {
        matchTxt.transform.Find("0").gameObject.SetActive(false);
        matchTxt.transform.Find("1").gameObject.SetActive(false);
        matchTxt.transform.Find("2").gameObject.SetActive(false);
        matchTxt.transform.Find("3").gameObject.SetActive(false);
        matchTxt.transform.Find("4").gameObject.SetActive(false);
        matchTxt.transform.Find("5").gameObject.SetActive(false);
        matchTxt.transform.Find("Fail").gameObject.SetActive(false);
    }

    //��ٸ޽�����


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

    void GameEnd()
    {
        Time.timeScale = 0.0f;
        countText.text = countText.ToString();
        end.SetActive(true);
    }
    //��ٸ޽����� ��ٽ�Ű�� ���� ��� ��
}
