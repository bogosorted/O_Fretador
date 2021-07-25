using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField, Range(0f, 10f)] float speed;
    [SerializeField] Animator anim;

    Vector2 direction;

    void Start()
    {
        
    }
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed).normalized;

        anim.SetBool("Andando",rb.velocity.magnitude != 0);
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            this.transform.up = direction;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = direction;
    }
}
