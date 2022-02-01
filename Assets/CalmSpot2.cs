using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CalmSpot2 : MonoBehaviour
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
        calming = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (calming == true)
        {
            zoom.GetComponent<CameraZoom>().smoothSpeed = -zoom.GetComponent<CameraZoom>().smoothSpeed;
            
            panel.color = Color.Lerp(panel.color, Color.white, Time.deltaTime * speed);
        }

        if (calming == false)
        {
            zoom.GetComponent<CameraZoom>().smoothSpeed = -zoom.GetComponent<CameraZoom>().smoothSpeed;
            
            panel.color = Color.Lerp(panel.color, Color.black, Time.deltaTime * speed);
        }
    }

    void OnCollisionStay2D (Collision2D collision)
    {
        calming = true;
        Calm.Play();
        Spooky.Stop();

    }

    void OnCollisionExit2D (Collision2D collision)
    {
        calming = false;
        Calm.Stop();
        Spooky.Play();
    }
}
