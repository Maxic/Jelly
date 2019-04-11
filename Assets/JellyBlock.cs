using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using UnityEngine;

public class JellyBlock : MonoBehaviour
{
	List<GameObject> cubes = new List<GameObject>();

	public GameObject smallCube;
    public int cubeSize;

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_EDITOR
        UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
        #endif

        for(var x=0; x < 6; x += 1){
        	for(var y=0; y < 6; y += 1){
        		for(var z=0; z < 6; z += 1){
                    GameObject cube = Instantiate(smallCube, new Vector3(x*.1f,y*.1f,z*.1f), new Quaternion(1,1,1,1)) as GameObject;
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
    }

		void AddJoint(GameObject cube, int x, int y, int z) {
			var originCube = cubes.FirstOrDefault(c => c.GetComponent<Coordinates>().X == x && c.GetComponent<Coordinates>().Y == y && c.GetComponent<Coordinates>().Z == z);
			if(originCube != null){
				FixedJoint fixedJoint = cube.AddComponent<FixedJoint>();
				fixedJoint.connectedBody = originCube.GetComponent<Rigidbody>();
			}
		}

    // Update is called once per frame
    void Update()
    {

    }
}
