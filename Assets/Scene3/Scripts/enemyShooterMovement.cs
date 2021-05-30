using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooterMovement : MonoBehaviour
{

    public Rigidbody2D enemy;
    public GameObject particles;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Spawn.currSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.position.x < -20) {
            Destroy(this.gameObject);
        }
        enemy.position += new Vector2(-1, 0) * speed * Time.deltaTime;    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser") {
            GameObject obj = Instantiate(particles, enemy.transform, false);
            obj.transform.parent = null;
            Destroy(this.gameObject);
            Spawn.score += 100;
        }
    }
}
