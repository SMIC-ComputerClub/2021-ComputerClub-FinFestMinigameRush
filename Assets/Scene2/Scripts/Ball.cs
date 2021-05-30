using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    

    [SerializeField]
    public TimeManagement timeManagement;
    [SerializeField]
    public CameraControl cameraControl;

    private Transform ballTransform;
    
    private float x = 0f;
    private float y = 0f;

    private float xDir;
    private float yDir;

    public float speed = 5f;
    public float increment = .5f;

    private float topBorder = 5f;
    private float sideBorder = 7f;

    private bool hitPaddle = false;

    public float repeat = 10f;

    private int life = 5;

    void Start()
    {
        ballTransform = GetComponent<Transform>();
        xDir = Random.Range(50f, 100f) * 0.01f * (Random.Range(0, 2) * 2 - 1);
        yDir = Random.Range(50f, 100f) * 0.01f;
    }

    // Update is called once per frame
    void Update()
    { 
        speed = Mathf.Clamp(speed, 0f, 30f);
        for (int i = 0; i < repeat; i++) StartCoroutine("BallMovement");
    }

    private bool HitHorizontal()
    {
        if ((ballTransform.position.x <= -sideBorder && xDir < 0) || (ballTransform.position.x >= sideBorder && xDir >=0))
        {
            return true;
        }
        return false;
    }

    private bool HitTop()
    {
        if (ballTransform.position.y >= topBorder && yDir > 0)
        {
            return true;
        }
        return false;
    }

    private bool HitBottom()
    {
        if (ballTransform.position.y <= -topBorder && yDir < 0)
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.tag == "Player" && yDir < 0)
        {
            hitPaddle = true;
            speed += increment;
        }
    }

    public float GetScore()
    {
        return speed * 2 - 20;
    }

    public float GetLife()
    {
        return life;
    }

    public void Setlife (int l)
    {
        life = l;
    }

    IEnumerator BallMovement()
    {
        ballTransform.position = new Vector2(x, y);
        x += xDir * speed * Time.deltaTime / repeat;
        y += yDir * speed * Time.deltaTime / repeat;

        if (HitHorizontal()) xDir *= -1;

        if (HitTop() && yDir > 0) yDir *= -1;

        if (HitBottom())
        {
            life--;
            x = 0f;
            y = 0f;
            xDir = Random.Range(50f, 100f) * 0.01f * (Random.Range(0, 2) * 2 - 1);
            yDir = Random.Range(50f, 100f) * 0.01f;
        }

        if (hitPaddle)
        {
            yDir *= -1;
            hitPaddle = false;
            if (timeManagement.isSuddenDeath())
            {
                cameraControl.Shake(0.025f, 0.2f);
            }
        }

        yield return null;
    }
}
