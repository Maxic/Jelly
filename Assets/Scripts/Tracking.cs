using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject myTarget = null;
    Vector3 myTargetLastKnownPosition = Vector3.zero;
    Quaternion myTargetLookAtRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myTarget)
        {
            if (myTargetLastKnownPosition != myTarget.transform.position)
            {
                myTargetLastKnownPosition = myTarget.transform.position;
                myTargetLookAtRotation = Quaternion.LookRotation(myTargetLastKnownPosition - transform.position);
            }


            if (transform.rotation != myTargetLookAtRotation)
            {

                transform.rotation = Quaternion.RotateTowards(transform.rotation, myTargetLookAtRotation, speed * Time.deltaTime);

            }
        }
    }
        bool SetTarget(GameObject target)
        {
            if(target)
            {
                return false;
            }
            myTarget = target;
            return true;
        }
    
}
