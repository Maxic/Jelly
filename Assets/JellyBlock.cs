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

        List<GameObject> cubes = new List<GameObject>();

        for(float i=0; i < .6f; i += .1f){
        	for(float j=0; j < .6f; j += .1f){
        		for(float h=0; h < .6f; h += .1f){
                    GameObject cube = Instantiate(smallCube, new Vector3(i,j,h), new Quaternion(1,1,1,1)) as GameObject;
                    cubes.Add(cube);

                    if (cubes.Count > 1){
                        for(int cubeIndex = 0; cubeIndex < cubes.Count-1; cubeIndex += 3){
                            FixedJoint fixedJoint = cube.AddComponent<FixedJoint>();
                            fixedJoint.connectedBody = cubes[cubeIndex].GetComponent<Rigidbody>();
                        }
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
