using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    public Text scoreText;
    [SerializeField]
    public Text timeText;
    [SerializeField]
    public TimeManagement timeManagement;

    [SerializeField]
    public Ball ball;

    private int timeElapsed;
    private string secElapsed;
    private string minElapsed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        displayTime();
        //displayScore();
        displayLife();
    }

    private void displayTime()
    {
        timeElapsed = timeManagement.GetTime();
        secElapsed = (timeElapsed % 60).ToString();
        if (timeElapsed % 60 < 10) secElapsed = "0" + secElapsed;
        minElapsed = (timeElapsed / 60).ToString();

        timeText.text = minElapsed + ":" + secElapsed;
    }

    private void displayScore()
    {
        scoreText.text = "Score: " + ball.GetScore().ToString();
    }

    private void displayLife()
    {
        scoreText.text = "Lives: " + ball.GetLife().ToString();
    }
}
