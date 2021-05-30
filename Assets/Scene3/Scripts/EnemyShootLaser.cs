using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootLaser : MonoBehaviour
{

    public float timeInBetween;
    public bool canShoot;
    public GameObject EnemyLaser;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForBullet());
    }

    IEnumerator waitForBullet()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeInBetween);
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot) {
            GameObject obj = Instantiate(EnemyLaser, this.transform,false);
            obj.transform.parent = null;
            StartCoroutine(waitForBullet());
        }
    }
}
