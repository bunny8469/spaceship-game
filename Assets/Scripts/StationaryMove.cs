using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryMove : MonoBehaviour
{

    public Rigidbody rb;

    public float maxSpeed = 100.0f;
    private float rotated = 0.0f;
    private float rotated_side = 0.0f;


    void FixedUpdate()
    {
        if(Input.GetKey("up")){
            if(rotated < 10.0f)
            {
                transform.Rotate(10.0f * 1.5f * Time.deltaTime, 0, 0, Space.Self);
                rotated += 10.0f * 1.5f * Time.deltaTime;
            }
            if (rb.velocity.z <= maxSpeed)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + maxSpeed / 20 * Time.deltaTime);
            }
        }
        else
        {
            if (rotated > 0.0f)
            {
                transform.Rotate(-10.0f * 1.5f * Time.deltaTime, 0, 0, Space.Self);
                rotated -= 10.0f * 1.5f * Time.deltaTime;
            }
        }
        if (Input.GetKey("down"))
        {
            if (rotated > -10.0f)
            {
                transform.Rotate(-10.0f * 1.5f * Time.deltaTime, 0, 0, Space.Self);
                rotated -= 10.0f * 1.5f * Time.deltaTime;
            }
            if(rb.velocity.z >= -maxSpeed)
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z - maxSpeed / 20.0f * Time.deltaTime);
        }
        else
        {
            if (rotated < 0.0f)
            {
                transform.Rotate(10.0f * 1.5f * Time.deltaTime, 0, 0, Space.Self);
                rotated += 10.0f * 1.5f * Time.deltaTime;
            }
        }
        if (Input.GetKey("left"))
        {
            if (rotated_side < 20.0f)
            {
                transform.Rotate(0, 0, 20.0f * 1.5f * Time.deltaTime, Space.World);
                rotated_side += 20.0f * 1.5f * Time.deltaTime;
            }
            if (rb.velocity.x >= -maxSpeed/2)
                rb.velocity = new Vector3(rb.velocity.x - maxSpeed / 20.0f * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        }
        else
        {
            if (rotated_side > 0.0f)
            {
                transform.Rotate(0, 0, -20.0f * 1.5f * Time.deltaTime, Space.World);
                rotated_side -= 20.0f * 1.5f * Time.deltaTime;
            }
        }
        if (Input.GetKey("right"))
        {
            if (rotated_side > -20.0f)
            {
                transform.Rotate(0, 0, -20.0f * 1.5f * Time.deltaTime, Space.World);
                rotated_side -= 20.0f * 1.5f * Time.deltaTime;
            }
            if (rb.velocity.x <= maxSpeed/2)
                rb.velocity = new Vector3(rb.velocity.x + maxSpeed / 20.0f * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        }
        else
        {
            if (rotated_side < 0.0f)
            {
                transform.Rotate(0, 0, 20.0f * 1.5f * Time.deltaTime, Space.World);
                rotated_side += 20.0f * 1.5f * Time.deltaTime;
            }
        }
    }
}
