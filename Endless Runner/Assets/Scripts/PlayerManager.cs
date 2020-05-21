﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public int timeOfGame;
    public float timer;

    public Text coinsText;
    public Text timeText;
    public Text speedText;
    
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        timeOfGame = 0;

        speed = 0;

        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        UpdateSpeed();
        
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        coinsText.text = "Coins: " + numberOfCoins;
        timeText.text = "Time: " + FormatTimeText();
        speedText.text = "Speed: " + FormatSpeedText();

        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
            
    }
    
    void UpdateTime()
    {
        if (isGameStarted)
        {
            timer += Time.deltaTime;
            timeOfGame =  Convert.ToInt32(timer);
        }
    }

    void UpdateSpeed()
    {
        GameObject player = GameObject.Find("Player");
        PlayerController controller = player.GetComponent<PlayerController>();
        speed = controller.displayedSpeed;
    }

    string FormatSpeedText()
    {
        return string.Format("{0} km/h", Convert.ToInt32(speed));
    }

    string FormatTimeText()
    {
        // return timeOfGame.ToString("D3") + "s"
        return (timeOfGame.ToString()).PadLeft(3, ' ') + "s";
    }
}
