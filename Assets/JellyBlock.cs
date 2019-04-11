using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class JellyBlock : MonoBehaviour
{
	public GameObject smallCube;
    public int cubeSize;

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_EDITOR
        UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
        #endif

        var cubes = new Dictionary<Vector3, GameObject>();
        Vector3 coordinates;
        GameObject originCube;

        for(float x=0; x < .6f; x += .1f){
        	for(float y=0; y < .6f; y += .1f){
        		for(float z=0; z < .6f; z += .1f){
                    coordinates = new Vector3(x,y,z);
                    GameObject cube = Instantiate(smallCube, coordinates, new Quaternion(1,1,1,1)) as GameObject;
                    cubes.Add(coordinates, cube);

                    if (cubes.Count > 1){
                        FixedJoint fixedJoint = cube.AddComponent<FixedJoint>();
                        cubes.TryGetValue(new Vector3(0,0,0), out originCube);
                        // remove this and connect to neighbours
                        fixedJoint.connectedBody = originCube.GetComponent<Rigidbody>();
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
