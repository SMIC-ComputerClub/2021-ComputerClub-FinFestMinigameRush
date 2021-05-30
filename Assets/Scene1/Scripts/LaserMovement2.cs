using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement2 : MonoBehaviour
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
        Vector2 force = transform.up * speed;
        beam.position +=  force * Time.deltaTime;
       if(beam.position.x > 16 || beam.position.y > 14 || beam.position.x < -16||beam.position.y < -14) {
            Destroy(this.gameObject);
        }
    }

   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "Asteriod") {
           Destroy(this.gameObject);
       }
   }
    
}
