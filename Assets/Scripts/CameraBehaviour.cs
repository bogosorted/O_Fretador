using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 initPos;
    void Start()
    {
        initPos = this.transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + initPos;
    }
}
