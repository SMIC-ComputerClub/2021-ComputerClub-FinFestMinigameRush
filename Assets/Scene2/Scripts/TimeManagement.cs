using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManagement : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer ballSprite;
    [SerializeField]
    public SpriteRenderer paddleSprite;
    [SerializeField]
    public Text timeText;
    [SerializeField]
    public Text livesText;

    

    private Color red = new Color (255, 0, 0);

    private int buffer = 2;
    public int timeElapsed = 0;
    public float timeEl = 0f;

    private bool first = true;
    public int suddenDeathTime = 20;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        timeEl = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeEl += Time.deltaTime;
        timeElapsed = (int)timeEl;
        if (isSuddenDeath())
        {
            SuddenDeath();
            if (first)
            {
                ballSprite.GetComponentInParent<Ball>().Setlife(1);
                first = false;
            }
        }
    }

    public int GetTime()
    { 
        return timeElapsed;
    }

    public bool isSuddenDeath()
    {
        if (timeElapsed >= suddenDeathTime)
        {
            return true;
        }
        return false;
    }

    private void SuddenDeath()
    {
        ballSprite.color = red;
        paddleSprite.color = red;
        timeText.color = red;
        livesText.color = red;
    }
}

