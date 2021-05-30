using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Settings : MonoBehaviour
{

    public string nextScene;

    public bool end; 

    public TimeManagement timeMan;

    public static int scoreGame2;

    public Text scoreText;
    public Text overAllText;

    public GameObject startScreen;
    public GameObject deathScreen;

    public bool gainNow;

    [SerializeField]
    public Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gainNow = true;
        scoreGame2 = 0;
        Time.timeScale = 0f;
        deathScreen.SetActive(false);
        startScreen.SetActive(true);
        Application.targetFrameRate = 60;
        end = true;
        
    }



    IEnumerator gainPoints()
    {   
        gainNow = false;
        yield return new WaitForSeconds(1f);
        gainNow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gainNow){
            if(timeMan.timeElapsed < 60) {
                scoreGame2 += 40;
            } else {
                scoreGame2 += 50;
            }
            StartCoroutine(gainPoints());
        }
        scoreText.text = "Score: " + scoreGame2;
        overAllText.text = "Overall Score: " + PlayerPrefs.GetInt("Overall Score");
        
        if (ball.GetLife() <= 0)
        {
            if(end) {
                endGame();
            }
            end = false;
        }

    }

    public void endGame() {
        deathScreen.SetActive(true);
        PlayerPrefs.SetInt("Overall Score", PlayerPrefs.GetInt("Overall Score") + scoreGame2);
        StopCoroutine(gainPoints());
        Time.timeScale = 0f;
    }

    public void nextGame() {
        SceneManager.LoadScene(nextScene);
    }

    public void startGame() {
        Time.timeScale = 1f;
        timeMan.timeElapsed = 0;
        startScreen.SetActive(false);
    }
    
}
