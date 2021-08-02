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
        transform.Translate((Vector3.up - Vector3.right * (!Navio.ancorado ? 0.140f : 0)) * speed * Time.deltaTime);
        print(barcoRb.velocity.y);
    }
}
