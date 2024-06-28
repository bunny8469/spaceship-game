using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Rigidbody rb;
    public Transform player;
    public Vector3 offset;

    private int time = 0;
    private float lev = 2.0f;

    void Start()
    {
        transform.position = player.position + offset;
    }

    void FixedUpdate()
    {
        if ((rb.velocity.x <= 0.1 && rb.velocity.x >= -0.1) && (rb.velocity.z <= 0.1 && rb.velocity.z >= -0.1))
        {
            if (time * Time.deltaTime <= lev)
            {
                transform.position += new Vector3(0, 0.05f * Time.deltaTime, 0);
                // rb.velocity = new Vector3(0, 2.5f * Time.deltaTime, 0);
                time++;
            }
            else if (time * Time.deltaTime <= lev * 3.0f)
            {
                transform.position += new Vector3(0, -0.05f * Time.deltaTime, 0);
                // rb.velocity = new Vector3(0, -2.5f * Time.deltaTime, 0);
                time++;
            }
            else if (time * Time.deltaTime <= lev * 4.0f)
            {
                transform.position += new Vector3(0, 0.05f * Time.deltaTime, 0);
                //rb.velocity = new Vector3(0, 2.5f * Time.deltaTime, 0);
                time++;
            }
            else if (time * Time.deltaTime > lev * 4.0f)
            {
                time = 0;
            }
        }
        else
        {
            transform.position = player.position + offset;
        }
    }
}
