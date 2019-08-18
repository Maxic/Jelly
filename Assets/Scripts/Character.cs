using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed;
    public float jumpHeight;
    

     void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        speed = 6f;
        jumpHeight = 500f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            rigidbody.velocity = Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            rigidbody.velocity = -Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            rigidbody.velocity = new Vector3(1,0,0) * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            rigidbody.velocity = new Vector3(-1,0,0) * speed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            rigidbody.velocity = new Vector3(0,1,0) * jumpHeight;
        }
    }

    bool IsGrounded(){
        return Physics.Raycast(transform.position, -Vector3.up, .4f);
    }
}