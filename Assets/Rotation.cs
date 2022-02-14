using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    
    public int force;
    

    // Start is called before the first frame update
    void Start()
    {
        force = 100;
       
    }

    // Update is called once per frame
    void Update()
    {

        this.GetComponent<Rigidbody2D>().angularVelocity = -force;
    }
    
}
