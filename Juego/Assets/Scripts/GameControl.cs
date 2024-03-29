﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public GameObject heart1, heart2, heart3, heart4, heart5, gameOver, restartButton, lose1, lose2, lose3, highscore, pause;

    public static int health;

    public Text highscoreText;

    public static GameControl instance;

    public GameObject player;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        heart4.gameObject.SetActive(false);
        heart5.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        lose1.gameObject.SetActive(false);
        lose2.gameObject.SetActive(false);
        lose3.gameObject.SetActive(false);
        highscore.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (health)
        {
            case 5:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(true);
                break;
            case 4:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(false);

                break;
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                highscoreText.text = "High Score= " +PlayerPrefs.GetInt("HighScore").ToString();
                gameOver.gameObject.SetActive(true);
                highscore.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                pause.gameObject.SetActive(false);

                if (ScoreScript.scoreValue <= 200)
                    lose1.gameObject.SetActive(true);
                if (ScoreScript.scoreValue <= 500 && ScoreScript.scoreValue > 200)
                    lose2.gameObject.SetActive(true);
                if (ScoreScript.scoreValue <= 1000 && ScoreScript.scoreValue > 500)
                    lose3.gameObject.SetActive(true);

                Time.timeScale = 0f;
                break;
        }
    }
}
