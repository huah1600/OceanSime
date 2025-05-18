using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SimpleWave : MonoBehaviour
{
    private Mesh meshs;
    private Vector3[] originalVertice;
    private Vector3[] displacedVertice;

    public float waveHeights = 0.5f;
    public float waveFrequence = 1f;
    public float waveSpeed = 1f;

    private void Start()
    {
        meshs = GetComponent<MeshFilter>().mesh;
        originalVertice = meshs.vertices;
        displacedVertice = new Vector3[originalVertice.Length];
        originalVertice.CopyTo(displacedVertice, 0);
    }

    private void Update()
    {
        for (int i = 0; i < displacedVertice.Length; i++)
        {
            Vector3 vertex = originalVertice[i];
            vertex.y = Mathf.Sin(Time.time * waveSpeed + vertex.x * waveFrequence + vertex.z * waveFrequence) * waveHeights;
            displacedVertice[i] = vertex;
        }
        meshs.vertices = displacedVertice;
        meshs.RecalculateNormals();
    }
}
