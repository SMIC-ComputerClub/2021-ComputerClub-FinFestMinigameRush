using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserMovement : MonoBehaviour
{
    public Rigidbody2D beam;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        beam = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 force = new Vector2(1, 0) * speed;
        beam.position +=  force * Time.deltaTime;
       if(beam.position.x > 20) {
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy" || col.tag == "EnemyLaser") {
            Destroy(this.gameObject);
        }
    }
    
    
}
