using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    // cannon rotation
    public int speed;
    public float friction;
    public float lerpSpeed;
    float xDegrees;
    float yDegrees;
    Quaternion fromRotation;
    Quaternion toRotation;
    Camera camera;

    //cannon firing
    public GameObject CannonBall;
    private Rigidbody cannonballRB;
    public Transform shotPos;
    public float firePower;
    public int powerMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        firePower *= powerMultiplier;
    }
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(ray, out hit))
        //{
        //    if (hit.transform.gameObject.tag == "Cannon")
        //    {
                if (Input.GetMouseButton(0))
                {
                    xDegrees -= Input.GetAxis("Mouse Y") * speed * friction;
                    yDegrees += Input.GetAxis("Mouse X") * speed * friction;
                    fromRotation = transform.rotation;
                    toRotation = Quaternion.Euler(xDegrees, yDegrees, 0);
                    transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);

                }
        //    }
        //}
        if (Input.GetMouseButton(1))
        {
            FireCannon();
        }
    }


    public void FireCannon()
    {
        shotPos.rotation = transform.rotation;
        GameObject cannonBallCopy = Instantiate(CannonBall, shotPos.position, shotPos.rotation) as GameObject;
        cannonballRB = cannonBallCopy.GetComponent<Rigidbody>();
        cannonballRB.AddForce(transform.forward * firePower);
      
    }
}
