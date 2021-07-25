using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField, Range(0f, 10f)] float speed;
    [SerializeField] Animator anim;

    Vector2 direction;

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Iinteractable>() != null)
        {
            StartCoroutine(Interact(other.gameObject));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Iinteractable>() != null)
        {
            StopCoroutine(Interact(other.gameObject));
        }
    }
    private IEnumerator Interact(GameObject objeto)
    {
        var teste = true;
        while(true)
        {
            if (teste)
            {
                teste = false;
            }
            if(Input.GetButtonDown("Fire1"))
            {
                objeto.GetComponent<Iinteractable>().Interact();
            }
            yield return null;
        }
    }
}
