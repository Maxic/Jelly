using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyCube : MonoBehaviour
{
    public float jellyFactor;
    public float upDownSpeed = 6f;
    protected MeshFilter meshFilter;
    protected Mesh mesh;
    protected MeshCollider meshCollider;
    protected Vector3[] cubeState;

    // Start is called before the first frame update
    void Start()
    {
        jellyFactor = 0.08f;

        mesh = new Mesh();
        mesh.name = "GeneratedMesh";
        cubeState = GenerateInitialState();
        mesh.vertices = GeneratedVertices(cubeState, new Vector3(0,0,0));
        mesh.triangles = GeneratedTriangles();

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        
        meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
        meshCollider.convex = true;
        
    }

    private Vector3[] GenerateInitialState(){
        return new Vector3[]{
            // Bottom
            new Vector3(-1,0 ,1),
            new Vector3(1,0 ,1),
            new Vector3(1,0 ,-1),
            new Vector3(-1,0 ,-1),
            // Top
            new Vector3(-1,2 ,1),
            new Vector3(1,2 ,1),
            new Vector3(1,2 ,-1),
            new Vector3(-1,2 ,-1),
            // Left
            new Vector3(-1,0 ,1),
            new Vector3(-1,0 ,-1),
            new Vector3(-1,2 ,1),
            new Vector3(-1,2 ,-1),
            // Right
            new Vector3(1,0 ,1),
            new Vector3(1,0 ,-1),
            new Vector3(1,2 ,1),
            new Vector3(1,2 ,-1),
            // Front
            new Vector3(1,0 ,-1),
            new Vector3(-1,0 ,-1),
            new Vector3(1,2 ,-1),
            new Vector3(-1,2 ,-1),
            // Back
            new Vector3(-1,0 ,1),
            new Vector3(1,0 ,1),
            new Vector3(-1,2 ,1),
            new Vector3(1,2 ,1),
        };
    }

    private Vector3[] GeneratedVertices(Vector3[] cubeState, Vector3 velocity){
        float left = velocity.x * jellyFactor;
        float right = (velocity.x * -1) * jellyFactor;

        float up = velocity.y * jellyFactor;
        float down = (velocity.y * -1) * jellyFactor;

        float back = velocity.z * jellyFactor;
        float forward = (velocity.z * -1) * jellyFactor;
        return new Vector3[]{
            // Bottom
            new Vector3(-1 + left,0 + down,1 + forward),
            new Vector3(1 + right,0 + down,1 + forward),
            new Vector3(1 + right,0 + down,-1 + back),
            new Vector3(-1 + left,0 + down,-1 + back),
            // Top
            new Vector3(-1 + left,2 + up,1 + forward),
            new Vector3(1 + right,2 + up,1 + forward),
            new Vector3(1 + right,2 + up,-1 + back),
            new Vector3(-1 + left,2 + up,-1 + back),
            // Left
            new Vector3(-1 + left,0 + down,1 + forward),
            new Vector3(-1 + left,0 + down,-1 + back),
            new Vector3(-1 + left,2 + up,1 + forward),
            new Vector3(-1 + left,2 + up,-1 + back),
            // Right
            new Vector3(1 + right,0 + down,1 + forward),
            new Vector3(1 + right,0 + down,-1 + back),
            new Vector3(1 + right,2 + up,1 + forward),
            new Vector3(1 + right,2 + up,-1 + back),
            // Front
            new Vector3(1 + right,0 + down,-1 + back),
            new Vector3(-1 + left,0 + down,-1 + back),
            new Vector3(1 + right,2 + up,-1 + back),
            new Vector3(-1 + left,2 + up,-1 + back),
            // Back
            new Vector3(-1 + left,0 + down,1 + forward),
            new Vector3(1 + right,0 + down,1 + forward),
            new Vector3(-1 + left,2 + up,1 + forward),
            new Vector3(1 + right,2 + up,1 + forward),
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
        cubeState = GeneratedVertices(cubeState, velocity);
        mesh.vertices = cubeState;
        meshCollider.sharedMesh = mesh;
        //var velocity = gameObject.GetComponent<Rigidbody>().velocity;
        //Debug.Log(velocity);
    }
}
