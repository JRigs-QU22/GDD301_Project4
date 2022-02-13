using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public Image panel;
    public float speed;
    //public float speed2;
    public Camera Zoom;
    //private Vector2 lposition;

    void Start()
    {
        //Right here. Make sure there's an image component attached,
        //or it will throw an error in Update()
        panel = GetComponent<Image>();
        
    }

    void Update()
    {
        //speed2 += Time.deltaTime;
        panel.color = Color.Lerp(panel.color, Color.black, Time.deltaTime * speed);
        //panel.color = GetRandomColor();
        //lposition = transform.position;
        //speed2 = 0;
        //Zoom.orthographicSize = Time.deltaTime * speed2;
        //Zoom.orthographicSize = Mathf.Lerp(Zoom.orthographicSize, Zoom.orthographicSize, Time.deltaTime * speed2);
    }

    /*
    Color GetRandomColor()
    {
        //return new Color(Color.red, , Random.value);
        
    }
    */
} //Based on code from: https://forum.unity.com/threads/changing-the-color-of-a-panel-in-code.286153/ and help from Professor Blake
