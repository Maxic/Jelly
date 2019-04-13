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

      for(var x=0; x < 5; x += 1){
      	for(var y=0; y < 5; y += 1){
      		for(var z=0; z < 5; z += 1){
            GameObject cube = Instantiate(smallCube, new Vector3(x*cubeSize,y*cubeSize,z*cubeSize), new Quaternion(1,1,1,1)) as GameObject;
            cube.layer = 2;
            cube.transform.parent = gameObject.transform;

						Coordinates coordinates = cube.GetComponent<Coordinates>();
						coordinates.X = x;
						coordinates.Y = y;
						coordinates.Z = z;

            cubes.Add(cube);

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
    }

		void AddJoint(GameObject cube, int x, int y, int z) {
			var neighbourCube = cubes.FirstOrDefault(c => c.GetComponent<Coordinates>().X == x && c.GetComponent<Coordinates>().Y == y && c.GetComponent<Coordinates>().Z == z);
			if(neighbourCube != null){
				FixedJoint joint = cube.AddComponent<FixedJoint>();
			  joint.connectedBody = neighbourCube.GetComponent<Rigidbody>();				
			}
		}

    // Update is called once per frame
    void Update()
    {

    }
}
