using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using UnityEngine;

public class JellyBlock : MonoBehaviour
{

    List<GameObject> cubes = new List<GameObject>();
    public GameObject smallCube;
    private float cubeSize;

    // Start is called before the first frame update
    void Start()
    {
      #if UNITY_EDITOR
      UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
      #endif

      cubeSize = smallCube.transform.localScale.x;

      for(var x=0; x < 3; x += 1){
      	for(var y=0; y < 3; y += 1){
      		for(var z=0; z < 3; z += 1){
          
            // Instantiate small cube
            // TODO: Make initPos relative to gameobject
            // TODO: Definition of smallcube in this script.
            Vector3 initialPos = new Vector3(x*cubeSize,y*cubeSize+10,z*cubeSize);
            GameObject cube = Instantiate(smallCube, initialPos, new Quaternion(1,1,1,1)) as GameObject;
            cube.layer = 2;
            cube.transform.parent = gameObject.transform;

						Coordinates coordinates = cube.GetComponent<Coordinates>();
					  coordinates.X = x;
            coordinates.Y = y;
						coordinates.Z = z;

            
            // if( x % 2 > 0 || y % 2 > 0 || z % 2 > 0){
            //   BoxCollider boxCollider = cube.GetComponent<BoxCollider>();
            //   boxCollider.size = new Vector3(.5f,.5f,.5f);
            //   Debug.Log(boxCollider.size);
            // }

            cubes.Add(cube);

            // Add joints between all cubes
            if (cubes.Count > 1){
							AddJoint(cube, x-1, y, z);
							AddJoint(cube, x+1, y, z);
							AddJoint(cube, x, y-1, z);
							AddJoint(cube, x, y+1, z);
							AddJoint(cube, x, y, z-1);
              AddJoint(cube, x, y, z+1);
            }
      		}
      	}
      }
      var middleCube = cubes.FirstOrDefault(c => c.GetComponent<Coordinates>().X == 2 && c.GetComponent<Coordinates>().Y == 2 && c.GetComponent<Coordinates>().Z == 2);
      var script = middleCube.AddComponent<Character>();
      middleCube.name = "Player";
      middleCube.tag = "Player"; 
    }

		void AddJoint(GameObject cube, int x, int y, int z) {
			var neighbourCube = cubes.FirstOrDefault(c => c.GetComponent<Coordinates>().X == x && c.GetComponent<Coordinates>().Y == y && c.GetComponent<Coordinates>().Z == z);
			if(neighbourCube != null){
				FixedJoint joint = cube.AddComponent<FixedJoint>();
        joint.breakForce = 100000;
			  joint.connectedBody = neighbourCube.GetComponent<Rigidbody>();				
			}
		}

    // Update is called once per frame
    void Update()
    {

    }

    private void OnJointBreak(float breakForce) {
      Debug.Log("Breaking!");
    }
}
