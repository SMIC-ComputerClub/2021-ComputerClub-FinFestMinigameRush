using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed;
    public Animator Anim;

    public float angularSpeed;
    public float maxVelocity;
    // Start is called before the first frame update

    public UIStuff GuiStuff;

    void Start()
    {
        
    }

    private void FixedUpdate() {
        player = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
    
        if(xAxis !=0) {
            player.constraints = RigidbodyConstraints2D.None;
        } else {
            player.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        if(yAxis != 0 || xAxis != 0) {
            Anim.SetBool("Moving", true);
        } else {
            Anim.SetBool("Moving", false);
        }

        ThrustForward(yAxis * speed);  
        ClampVelocity(); 
        Rotate(player.transform, xAxis * -angularSpeed);

    }

    private void ClampVelocity() {
        float x = Mathf.Clamp(player.velocity.x, - maxVelocity, maxVelocity);
        float y = Mathf.Clamp(player.velocity.y, -maxVelocity, maxVelocity);
        player.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount) {
        Vector2 force = transform.up * amount;
        player.AddForce(force);
    }

    private void Rotate(Transform t, float amount) {
        t.Rotate(0, 0, amount);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Asteriod") {
            GuiStuff.endGame();
        }
    }

}
