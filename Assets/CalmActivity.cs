using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalmActivity : MonoBehaviour
{
    public bool Breathing;
    public int BreathCount;
    public float BreathTimer;

    public Image panel;
    public float speed;
    public AudioSource Spooky;
    public AudioSource Calm;
    public bool calming = false;
    public Camera zoom;

    // Start is called before the first frame update
    void Start()
    {
        Breathing = false;
        BreathCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && BreathCount > 0)
        {
            
            Breathing = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Breathing = false;
            BreathCount = BreathCount - 1;
        }

        if (Breathing == true)
        {
            zoom.GetComponent<CameraZoom>().smoothSpeed = -zoom.GetComponent<CameraZoom>().smoothSpeed;

            panel.color = Color.Lerp(panel.color, Color.clear, Time.deltaTime * speed);

            Calm.Play();
            Spooky.Stop();
        }
        if (Breathing == false)
        {
            zoom.GetComponent<CameraZoom>().smoothSpeed = -zoom.GetComponent<CameraZoom>().smoothSpeed;

            Calm.Stop();
            Spooky.Play();
        }

        if (BreathCount < 0)
        {
            BreathCount = 0;
        }
    }
}
