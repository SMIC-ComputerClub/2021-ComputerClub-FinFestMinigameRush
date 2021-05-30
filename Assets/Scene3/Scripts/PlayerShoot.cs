using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject laser;
    private bool ready;

    // Start is called before the first frame update
    void Start()
    {
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.X) && ready) {
            StartCoroutine(Delay());
            GameObject obj = Instantiate(laser, this.transform,false);
            obj.transform.parent = null;
        }
    }

    IEnumerator Delay()
    {
        ready = false;
        yield return new WaitForSeconds(0.6f);
        ready = true;
    }
}
