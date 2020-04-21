using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public Image panel;
    int SceneCount = 0;
    public AudioSource Walk;
    public AudioSource Hit;
    public bool isMoving = false;
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) //if d key is pressed, move in right direction
        {
            isMoving = true;
            //Walk.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(4, 0);
            
        }
        else if (Input.GetKey(KeyCode.A)) //if a key is pressed, move in left direction
        {
            isMoving = true;
            //Walk.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
            
        }
        else if (Input.GetKey(KeyCode.W)) //if spacebar is pressed, move in up direction
        {
            isMoving = true;
            //Walk.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 4);
            
        }
        else if (Input.GetKey(KeyCode.S)) //if down arrow key is pressed, move in down direction
        {
            isMoving = true;
            //Walk.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -4);
            
        }
        else
        {
            isMoving = false;
            //Walk.Stop();
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //if neither is pressed, don't move at all
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) && isMoving == true)
        {
            Walk.Play();
        }
        else if (isMoving == false)
        {
            Walk.Stop();
        }
       if (Input.GetKeyDown(KeyCode.R)) //if down arrow key is pressed, move in down direction
        {
            SceneManager.LoadScene(1);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Hit.Play();
        }
        if (collision.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.tag == "QTE")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Breathing");
                panel.color = Color.Lerp(panel.color, Color.white, Time.deltaTime * speed);
            }
        }


    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "QTE")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                panel.color = Color.Lerp(panel.color, Color.white, Time.deltaTime * speed);
            }
        }
    }
    */

}

        //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D))
