using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    
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

}
