using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodMovement : MonoBehaviour
{

    public Rigidbody2D body;
    public float speed;
    public Transform explosion;

    private float xDir;
    private float yDir;
    
    private float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {

        rotSpeed = Random.Range(0f, 6);

        float x = body.position.x;
        float y = body.position.y;

        float xDir = 0f;
        float yDir = 0f;

        //Q1
        if(x > 0 && y > 0)  {
            xDir = Random.Range(-1f, 0f);
            yDir = Random.Range(-1f, 0f);
        } else if (x > 0 && y < 0) { //Q4
            xDir = Random.Range(-1f, 0f);
            yDir = Random.Range(0f, 1f);
        } else if (x < 0 && y < 0) { //Q3
            xDir = Random.Range(0f, 1f);
            yDir = Random.Range(0f, 1f);
        } else { //Q2
            xDir = Random.Range(0f, 1f);
            yDir = Random.Range(-1f, 0f);
        }
        setDir(xDir, yDir);
    }

    public void setDir(float x, float y) {
        xDir = x;
        yDir = y;
    }

    void Update()
    {
        this.transform.Rotate(0, 0, rotSpeed);
        MoveTowards(xDir, yDir);
        if(body.position.x > 16 || body.position.y > 14 || body.position.x < -16||body.position.y < -14) {
            Destroy(this.gameObject);
        }
    }

    public void MoveTowards(float x, float y) {
        body.position += new Vector2(x, y) * speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser") {
            var obj = Instantiate(explosion, body.transform, false);
            obj.transform.parent = null;
            UIStuff.score += 100;
            Destroy(this.gameObject);
        }
    }
}
