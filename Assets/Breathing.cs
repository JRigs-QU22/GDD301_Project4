using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breathing : MonoBehaviour
{
    public Image panel;
    public float Speed;
    private bool dirUp = true;
    public float speed = 2.0f;
    public AudioSource breathing;
    public Camera zoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dirUp)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.up * speed * Time.deltaTime);

        if (transform.position.y >= -1.0f)
        {
            dirUp = false;
        }

        if (transform.position.y <= -4)
        {
            dirUp = true;
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Breathe");
        }
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag == "Player")
            {

                Debug.Log("Breathe");
            }
            if (collision.gameObject.tag == "Player")
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    zoom.GetComponent<CameraZoom>().smoothSpeed = -4f;
                    breathing.Play();
                    panel.color = Color.Lerp(panel.color, Color.white, Time.deltaTime * Speed);
                }
            }
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        zoom.GetComponent<CameraZoom>().smoothSpeed = 0.2f;
    }
} //Based on code from: https://answers.unity.com/questions/690884/how-to-move-an-object-along-x-axis-between-two-poi.html

