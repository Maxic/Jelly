using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class JellyBlock : MonoBehaviour
{
	public GameObject smallCube;

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_EDITOR
        UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
        #endif
        GameObject oldCube = null;
        GameObject newCube = null;

        for(float i=0; i < .6f; i += .1f){
        	for(float j=0; j < .6f; j += .1f){
        		for(float h=0; h < .6f; h += .1f){
					oldCube = newCube;
                    newCube = Instantiate(smallCube, new Vector3(i,j,h), new Quaternion(1,1,1,1)) as GameObject;
                    
                    if (oldCube != null){
                        SpringJoint SpringJoint = newCube.AddComponent<SpringJoint>();
                    }
        		}
        	}
        }
        


         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
