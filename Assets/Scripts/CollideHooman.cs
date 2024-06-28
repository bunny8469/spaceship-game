using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollideHooman : MonoBehaviour
{
    public Rigidbody rb;
    public Text text;
    public Text timeText;
    public Text gameOver;
    public float Force = 600.0f;
    private int hoomans = 0;
    public float time = 100.0f;

    // private float rotated = 0.0f;
    // private bool shouldRotate = false;
    private void Start()
    {
        gameOver.gameObject.SetActive(false);
        Debug.Log(gameObject.GetComponent<ChangeValues>().planeDimensionX);
        gameObject.GetComponent<ChangeValues>().Change();
    }

    void FixedUpdate()
    {
        if(time >= 0)
        {
            time -= 1.0f * Time.deltaTime;
            timeText.text = time.ToString("0");
        }
        else
        {
            gameOver.gameObject.SetActive(true);
        }
        /* if (rotated < 360.0f && shouldRotate)
        {
            transform.Rotate(0, 1000.0f * Time.deltaTime, 0, Space.World);
            gameObject.transform.GetChild(2).Rotate(0, -1000.0f * Time.deltaTime, 0, Space.World);
            rotated += 1000.0f * Time.deltaTime;
        }
        else
        {
            shouldRotate = false;
            rotated = 0.0f;
        } */
    }
    private void OnTriggerEnter(Collider other)
    {
        if(time >= 0)
        {
            if (other.gameObject.tag == "Hooman")
            {
                rb.drag = 5;
                gameObject.transform.GetChild(2).GetComponent<Light>().intensity = 2.0f;
            }
            if (other.tag == "Hooman Container")
            {
                Destroy(other.gameObject);
                hoomans++;
                rb.drag = 0.5f;
                gameObject.transform.GetChild(2).GetComponent<Light>().intensity = 1.69f;
                text.text = hoomans.ToString();
                // shouldRotate = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(time >= 0)
        {
            other.attachedRigidbody.AddForce(0, Force * Time.deltaTime, 0);
            other.attachedRigidbody.transform.Rotate(0, 69.0f * Time.deltaTime, 0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hooman")
        {
            other.attachedRigidbody.velocity = new Vector3(0, 0, 0);
            rb.drag = 0.5f;
            gameObject.transform.GetChild(2).GetComponent<Light>().intensity = 1.69f;
        }
    }
}
