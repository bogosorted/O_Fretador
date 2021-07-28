using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaveManager : MonoBehaviour
{
    static public WaveManager instance;
    private MeshFilter mf;
    [SerializeField]private float amplitude = 1f, length = 2f, speed = 1f, offset = 0f;
    void Awake()
    {
        if(instance == null)
            instance = this;
        mf = GetComponent<MeshFilter>();
    }

    void Update()
    {
        offset += speed * Time.deltaTime;
        Vector3[] vertices = mf.mesh.vertices;
        for(int i = 0; i < vertices.Length; i++){
            vertices[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + vertices[i].x);
        }
        mf.mesh.vertices = vertices;
        mf.mesh.RecalculateNormals();
    }

    public float GetWaveHeight(float x){
        return amplitude * Mathf.Sin(x / length + offset);
    }
}
