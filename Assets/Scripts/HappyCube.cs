using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyCube : MonoBehaviour
{
    public float upDownFactor;
    public float upDownSpeed = 6f;
    protected MeshFilter meshFilter;
    protected Mesh mesh;
    protected MeshCollider meshCollider;

    // Start is called before the first frame update
    void Start()
    {
        upDownFactor = 0.05f;

        mesh = new Mesh();
        mesh.name = "GeneratedMesh";

        mesh.vertices = GeneratedVertices(new Vector3(0,0,0));
        mesh.triangles = GeneratedTriangles();

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        
        meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
        meshCollider.convex = true;
        
    }

    private Vector3[] GeneratedVertices(Vector3 velocity){
        float left = velocity.x;
        float right = (velocity.x * -1);

        float up = velocity.y * upDownFactor;
        float down = (velocity.y * -1) * upDownFactor;
        
        Debug.Log("UpDownFactor: " + upDownFactor);
        Debug.Log("VelocityUp: " + velocity.y);
        Debug.Log("Up: " + up);
        Debug.Log("Should be up: " + (velocity.y * upDownFactor));
        Debug.Log("VelocityDown: " + velocity.y *-1);
        Debug.Log("down: " + down);

        float back = velocity.z;
        float forward = velocity.z * -1;
        return new Vector3[]{
            // Bottom
            new Vector3(-1,0 + down,1),
            new Vector3(1,0 + down,1),
            new Vector3(1,0 + down,-1),
            new Vector3(-1,0 + down,-1),
            // Top
            new Vector3(-1,2 + up,1),
            new Vector3(1,2 + up,1),
            new Vector3(1,2 + up,-1),
            new Vector3(-1,2 + up,-1),
            // Left
            new Vector3(-1,0 + down,1),
            new Vector3(-1,0 + down,-1),
            new Vector3(-1,2 + up,1),
            new Vector3(-1,2 + up,-1),
            // Right
            new Vector3(1,0 + down,1),
            new Vector3(1,0 + down,-1),
            new Vector3(1,2 + up,1),
            new Vector3(1,2 + up,-1),
            // Front
            new Vector3(1,0 + down,-1),
            new Vector3(-1,0 + down,-1),
            new Vector3(1,2 + up,-1),
            new Vector3(-1,2 + up,-1),
            // Back
            new Vector3(-1,0 + down,1),
            new Vector3(1,0 + down,1),
            new Vector3(-1,2 + up,1),
            new Vector3(1,2 + up,1),
        };
    }

    private int[] GeneratedTriangles(){
        return new int[]{
            // Bottom
            1,0,2,
            2,0,3,
            // Top
            4,5,6,
            4,6,7,
            // Left
            9,10,11,
            8,10,9,
            // Right
            12,13,15,
            14,12,15,
            // Front
            16,17,19,
            18,16,19,
            // Back
            20,21,23,
            22,20,23
        };
    }

    
    // Update is called once per frame
    void Update()
    {
        var velocity = gameObject.GetComponent<Rigidbody>().velocity;
        mesh.vertices =  GeneratedVertices(velocity);
        meshCollider.sharedMesh = mesh;
        //var velocity = gameObject.GetComponent<Rigidbody>().velocity;
        //Debug.Log(velocity);
    }
}
