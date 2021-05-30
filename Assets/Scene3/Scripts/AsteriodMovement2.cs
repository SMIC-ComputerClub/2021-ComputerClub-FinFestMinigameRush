using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodMovement2 : MonoBehaviour
{

    public Rigidbody2D enemy;
    public GameObject particles;
    private float rotSpeed;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Spawn.currSpeed;
        rotSpeed = Random.Range(0f, 6);   
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, rotSpeed);
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
            Spawn.score += 50;
        }
    }
}
