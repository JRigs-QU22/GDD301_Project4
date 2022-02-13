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
    public bool calming = false;
    public Camera zoom;

   public CameraShake Shake;

  

    // Start is called before the first frame update
    void Start()
    {
        
        //Breathing = false;
        Spooky.Play();
        Calm.Stop();
        BreathCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.Space) && BreathCount > 0)
        {
            
            Breathing = true;
            panel.color = Color.Lerp(panel.color, Color.clear, Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Breathing == true)
        {
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
            
            Shake.enabled = true;
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
    }

}
