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
    public AudioSource ScaredBreath;
    public AudioSource CalmBreath;
    public AudioSource QTE;
    public bool calming = false;
    public Camera zoom;

   public CameraShake Shake;
    public Move Movement;
    public Text Rests;
  

    // Start is called before the first frame update
    void Start()
    {
        
        //Breathing = false;
        Spooky.Play();
        Calm.Stop();
        BreathCount = 3;
        Rests.text = "Rests Available: " + BreathCount;
    }

    // Update is called once per frame
    void Update()
    {

        Rests.text = "Rests Available: " + BreathCount;
        if (Input.GetKey(KeyCode.Space) && BreathCount > 0)
        {
            
            Breathing = true;
            panel.color = Color.Lerp(panel.color, Color.clear, Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Breathing == true)
        {
            Movement.enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Shake.enabled = false;
            Calm.Play();
            Spooky.Stop();
            CalmBreath.Play();
            ScaredBreath.Stop();
            Debug.Log("Calm");
            zoom.GetComponent<CameraZoom>().smoothSpeed = -zoom.GetComponent<CameraZoom>().smoothSpeed;

        }
            if (Input.GetKeyUp(KeyCode.Space))
        {
            Movement.enabled = true;
            Shake.enabled = true;
            Shake.shakeTime = 0f;
            Shake.shakeMagnetude = 0f;
            Shake.Countdown = 3.0f;
            Breathing = false;
            BreathCount = BreathCount - 1;
            Calm.Stop();
            Spooky.Play();
            CalmBreath.Stop();
            ScaredBreath.Play();
            Debug.Log("spooky)");
            zoom.GetComponent<CameraZoom>().smoothSpeed = -zoom.GetComponent<CameraZoom>().smoothSpeed;
        }

        if (Breathing == true)
        {
            

            panel.color = Color.Lerp(panel.color, Color.clear, Time.deltaTime * speed);
            
            
            
            
        }
        if (Breathing == false)
        {
            

            
        }

        if (BreathCount < 0)
        {
            BreathCount = 0;
        }
        if (BreathCount > 3)
        {
            BreathCount = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "QTE")
        {

            Debug.Log("Breathe");
        }
        if (collision.gameObject.tag == "QTE")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                zoom.GetComponent<CameraZoom>().smoothSpeed = -4f;
                QTE.Play();
                BreathCount = BreathCount + 1;

                //panel.color = Color.Lerp(panel.color, Color.clear, Time.deltaTime * Speed);
            }
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        zoom.GetComponent<CameraZoom>().smoothSpeed = 0.2f;
    }

}
