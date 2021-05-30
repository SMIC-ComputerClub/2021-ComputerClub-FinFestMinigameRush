using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    public TimeManagement timeManagement;

    private Camera cam;
    private Vector3 defaultPos;

    private int isSuddenDeath = 0;
    private float shake;
    private float length;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        defaultPos = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManagement.isSuddenDeath())
        {
            isSuddenDeath++;
        }

        if (isSuddenDeath == 1)
        {
            Shake(.05f, .3f);
        }
    }

    public void Shake(float s, float l)
    {
        shake = s;
        length = l;
        InvokeRepeating("BeginShake", 0, 0.005f);
        Invoke("StopShake", length);
    }


    void BeginShake()
    {
        if (shake > 0)
        {
            Vector3 camPos = cam.transform.position;

            float offsetX = Random.value * shake * 2 - shake;
            float offsetY = Random.value * shake * 2 - shake;

            camPos.x += offsetX;
            camPos.y += offsetY;

            cam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        cam.transform.position = defaultPos;
    }

}
