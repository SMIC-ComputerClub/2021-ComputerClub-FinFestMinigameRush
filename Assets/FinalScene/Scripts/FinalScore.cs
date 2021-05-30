using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{

    public string restart;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Your Score: " + PlayerPrefs.GetInt("Overall Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void restartGame() {
         SceneManager.LoadScene(restart);
     }
}
