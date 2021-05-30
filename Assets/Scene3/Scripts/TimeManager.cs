using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    public Text timeText;
    public static float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 60) {
            timeText.color = Color.red;
        }
        currentTime += Time.deltaTime;
        if(currentTime < 10) {
            timeText.text = ("Time: " + currentTime).Substring(0,9);
        } else {
            timeText.text = ("Time: " + currentTime).Substring(0,10);
        }
    }
}
