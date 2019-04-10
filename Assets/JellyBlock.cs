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
        
        for(float i=0; i < .6f; i += .1f){
        	for(float j=0; j < .6f; j += .1f){
        		for(float h=0; h < .6f; h += .1f){
					GameObject cube = Instantiate(smallCube, new Vector3(i,j,h), new Quaternion(1,1,1,1)) as GameObject;
                    //cube.GetComponent<Renderer>().material = material;
                    //Rigidbody2D body = cube.AddComponent<Rigidbody2D>();
                    //BoxCollider2D collider = cube.AddComponent<BoxCollider2D>();
                    //collider.sharedMaterial = bouncy;
                    //collider.size = new Vector2(2f,2f);
                    //body.sharedMaterial = bouncy;
                    
        		}
        	}
        }
        


         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
