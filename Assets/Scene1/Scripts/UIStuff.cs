using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStuff : MonoBehaviour
{
    public float time;
    public static int score;
    public GameObject deathScreen;
    public GameObject startScreen;

    public string nextScene;

    public Text scoreText;
    public Text timeText;
    public Text score2;
    public Text overAllScoreText;

    public AsteriodSpawner spawner;


    private bool addScoreNow;
    
    // Start is called before the first frame update
    void Start()
    {

        startScreen.SetActive(true);
        Time.timeScale = 0f;
        addScoreNow = false;
        StartCoroutine(addScore());
        score = 0;
        time = 0f;
        deathScreen.SetActive(false);
    }

    public void startGame() {
        startScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    IEnumerator addScore()
    {
        addScoreNow = false;
        yield return new WaitForSeconds(1f);
        addScoreNow = true;
    }

    // Update is called once per frame
    void Update()
    {
        overAllScoreText.text = "Overall Score: " + (PlayerPrefs.GetInt("Overall Score")+ "");
        if(addScoreNow) {
            score += 10;
            StartCoroutine(addScore());
        }
        time += Time.deltaTime;
        if(time < 10) {
            timeText.text = ("Time: " + time).Substring(0,9);
        } else {
            timeText.text = ("Time: " + time).Substring(0,10);
        }
        
        if(time > 60) {
            timeText.color = Color.red;
        }

        scoreText.text = "Score: " + score;  
        score2.text =  "Score: " + score;  
        if(time > 5) {
            spawner.timeInBetween = 3f;
        }
        if(time > 15) {
            spawner.timeInBetween = 2f;
        }
        if(time > 25) {
            spawner.timeInBetween = 1.5f;
        }
        if(time > 25) {
            spawner.timeInBetween = 1f;
        }
        if(time > 30) {
            spawner.timeInBetween = 0.9f;
        }
        if(time > 50) {
            spawner.timeInBetween = 0.6f;
        }
        if(time > 60) {
            spawner.timeInBetween = 0.3f;
        }
        if(time > 75) {
            spawner.timeInBetween = 0.2f;
        }
        if(time > 85) {
            spawner.timeInBetween = 0.05f;
        }
    }

    public void endGame() {
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
        PlayerPrefs.SetInt("Overall Score", PlayerPrefs.GetInt("Overall Score") + score);
    }

    public void next() {
        SceneManager.LoadScene(nextScene);
    }

}
