using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSelfDestruct : MonoBehaviour
{

    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeLeft);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
