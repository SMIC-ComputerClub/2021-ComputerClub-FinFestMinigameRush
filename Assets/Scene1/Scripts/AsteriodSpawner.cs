using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodSpawner : MonoBehaviour
{

    public GameObject asteriod;
    public float timeInBetween;
    public bool timeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = true;
    }

    IEnumerator waitSpawn() {
        timeToSpawn = false;
        yield return new WaitForSeconds(timeInBetween);
        timeToSpawn = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(timeToSpawn) {        
            float x = Random.Range(-14f, 14f);
            float y = Random.Range(-12f, 12f);
            if(x < 10 || x > -10) {
                float rng = Random.Range(0f,2f);
                if(rng < 1f) {
                    x = 10;
                } else {
                    x = -10;
                }
            } 
            if(y < 7 || y > -7) {
                float rng = Random.Range(0f,2f);
                if(rng < 1f) {
                    y = 7;
                } else {
                    y = -7;
                }
            }
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            GameObject spawn = Instantiate(asteriod, new Vector3(x, y, 0), rotation);
            StartCoroutine(waitSpawn());
        }
    }
}
