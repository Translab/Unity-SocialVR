using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour {

    List<Vector3> vertices;
    List<Vector3> verticesORG;
    Mesh mesh;

    public Transform player1;
    public Transform player2;
	// Use this for initialization
	void Start () {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = new List<Vector3>(mesh.vertices);
        verticesORG = new List<Vector3>(mesh.vertices);
    }
	
	// Update is called once per frame
	void Update () {
        if (player1)
        {
            for(int i=0; i< vertices.Count; i++)
            {
                float dist = 1f/(player1.position - transform.TransformPoint(verticesORG[i])).sqrMagnitude;
                vertices[i] = new Vector3(verticesORG[i].x, verticesORG[i].y - dist, verticesORG[i].z);
            }
        }

        if (player2&&player1)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                float dist1 = 1f / (player1.position - transform.TransformPoint(verticesORG[i])).sqrMagnitude;
                float dist2 = 1f / (player2.position - transform.TransformPoint(verticesORG[i])).sqrMagnitude;

                vertices[i] = new Vector3(verticesORG[i].x, (verticesORG[i].y - dist1 - dist2), verticesORG[i].z);
            }
        }


        mesh.vertices = vertices.ToArray();
	}
}
