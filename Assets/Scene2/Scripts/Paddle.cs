using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Transform paddleTransform;
    private Vector2 mousePos;

    private float fixedY = -4f;
    private float x;

    private float sideBorder = 7f;

    // Start is called before the first frame update
    void Start()
    {
        paddleTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Movement");
    }

    IEnumerator Movement()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        x = Mathf.Clamp(mousePos.x, -sideBorder, sideBorder);

        paddleTransform.position = new Vector2(x, fixedY);
        yield return null;
    }
}
