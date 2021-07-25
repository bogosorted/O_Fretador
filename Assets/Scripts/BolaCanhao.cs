using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaCanhao : MonoBehaviour
{
    float speed = 10;
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
