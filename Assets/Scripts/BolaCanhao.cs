using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaCanhao : MonoBehaviour
{
    public Rigidbody barcoRb;
    public Navio navio;
    float speed = 20;
    void Update()
    {
        transform.Translate(new Vector3(barcoRb.velocity.y/navio.speed, speed, 0) * Time.deltaTime);
    }
}
