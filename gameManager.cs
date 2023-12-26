using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public Text timeTxt;
    public Text endMatchNum;

    public GameObject endTxt;
    public GameObject card;
    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject endPanel;

    public AudioClip match;
    public AudioSource audioSource;
    public static gameManager I;

    int count = 0;
    float time = 0.0f;

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        Time.timeScale = 1.0f;

        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time > 30.0f)
        {
            endPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);

            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                endPanel.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }


        firstCard = null;
        secondCard = null;

        count += 1;
        endMatchNum.text = count.ToString();
    }

    void GameEnd()
    {
        Time.timeScale = 0.0f;
        endMatchNum.text = endMatchNum.ToString();
        endPanel.SetActive(true);
    }

    public void retryGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}