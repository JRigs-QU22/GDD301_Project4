using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CalmSpot : MonoBehaviour
{
    public Image panel;
    public float speed;
    public AudioSource Spooky;
    public AudioSource Calm;
    public bool calming = false;


    public Camera zoom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float scroll = Input.GetAxis("Mouse ScrollWheel");


        
    }
   
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Debug.Log("Calm");
            panel.color = Color.Lerp(panel.color, Color.white, Time.deltaTime * speed);
            //zoom.GetComponent<CameraZoom>().enabled = false;
            //smoothSpeed = -smoothSpeed;
            //zoom.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
            //zoom.GetComponent<CameraZoom>().smoothSpeed = -zoom.GetComponent<CameraZoom>().smoothSpeed;

            if (calming == false)
            {
                calming = true;
                Spooky.Stop();
                Calm.Play();
                zoom.GetComponent<CameraZoom>().smoothSpeed = -zoom.GetComponent<CameraZoom>().smoothSpeed;
            }
        }
        else
        {
            calming = false;
            //zoom.GetComponent<CameraZoom>().enabled = true;
            Spooky.Play();
            Calm.Stop();
        }
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        calming = false;
        zoom.GetComponent<CameraZoom>().smoothSpeed = -zoom.GetComponent<CameraZoom>().smoothSpeed;
        Spooky.Play();
        Calm.Stop();
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Calm");
            panel.color = Color.Lerp(panel.color, Color.white, Time.deltaTime * speed);
            //zoom.GetComponent<CameraZoom>().enabled = false;
            zoom.GetComponent<CameraZoom>().smoothSpeed = -zoom.GetComponent<CameraZoom>().smoothSpeed;
            //zoom.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);

            if (calming == false)
            {
                calming = true;
                //smoothSpeed = +smoothSpeed;
                Spooky.Stop();
                Calm.Play();
            }
        }
        else
        {
            calming = false;
            //zoom.GetComponent<CameraZoom>().enabled = true;
            Spooky.Play();
            Calm.Stop();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        calming = false;
        //zoom.GetComponent<CameraZoom>().enabled = true;
        zoom.GetComponent<CameraZoom>().smoothSpeed = 0.2f;
        Spooky.Play();
        Calm.Stop();
    }
    */
}
