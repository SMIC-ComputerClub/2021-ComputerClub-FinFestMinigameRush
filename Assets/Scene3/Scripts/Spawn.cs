using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{

    public string nextScene;
    public static float currSpeed;
    public static float bulletSpeed;
    public GameObject[] obstacles;
    public bool canSpawn;
    public float timeBetweenSpawn;

    public Text scoreText1;
    public Text scoreText2;
    public Text overallScoreText;

    public static int score;
    public bool canGainPoints;

    public GameObject startScreen;
    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Time.timeScale = 0f;
        startScreen.SetActive(true);
        deathScreen.SetActive(false);
        currSpeed = 5f;
        timeBetweenSpawn = 1.8f;
        bulletSpeed = 8f;
        canSpawn = false;
        StartCoroutine(delaySpawn());
        StartCoroutine(gainPointsNow());
    }

    IEnumerator gainPointsNow()
    {
        canGainPoints = false;
        yield return new WaitForSeconds(5f);
        canGainPoints = true;
    }

    public void startGame() {
        startScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void endGame() {
        deathScreen.SetActive(true);
        PlayerPrefs.SetInt("Overall Score", PlayerPrefs.GetInt("Overall Score") + score);
        overallScoreText.text = "Overall Score: "  + PlayerPrefs.GetInt("Overall Score");
        Time.timeScale = 0f;

    }

    IEnumerator delaySpawn()
    {
        canSpawn = false;
        yield return new WaitForSeconds(timeBetweenSpawn);
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText1.text = "Score: " + score;
        scoreText2.text = "Score: " + score;
        if(canGainPoints) {
            score += 50;
            StartCoroutine(gainPointsNow());
        }
        if(canSpawn) {
            int index = (int)(Random.Range(0, obstacles.Length));
            GameObject temp = obstacles[index];
            float ySpawn = Random.Range(-4f, 4f);
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            GameObject obj = Instantiate(temp, new Vector2(20, ySpawn),rotation);
            obj.transform.parent = null;
            StartCoroutine(delaySpawn());
        }
        if(TimeManager.currentTime > 15) {
            currSpeed = 6f;
            timeBetweenSpawn = 1.7f;
        }
        if(TimeManager.currentTime > 25) {
            currSpeed = 7f;
            timeBetweenSpawn = 1.5f;
        } 
        if(TimeManager.currentTime > 30) {
            currSpeed = 7f;
            timeBetweenSpawn = 1.3f;
        }
        if(TimeManager.currentTime > 40) {
            currSpeed = 8f;
            timeBetweenSpawn = 1f;
        } 
        if(TimeManager.currentTime > 50) {
            currSpeed = 8f;
            timeBetweenSpawn = 0.8f;
        }
        if(TimeManager.currentTime > 60) {
            currSpeed = 9f;
            timeBetweenSpawn = 0.5f;
        }
        if(TimeManager.currentTime > 70) {
            currSpeed = 12f;
            timeBetweenSpawn = 0.2f;
        }
        bulletSpeed = currSpeed + 5f;
    }

    public void finishGame() {
        SceneManager.LoadScene(nextScene);
    }
}
