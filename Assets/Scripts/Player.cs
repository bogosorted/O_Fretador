using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField, Range(0f, 10f)] float speed;
    [SerializeField] Animator anim;
    Coroutine interact;
    public bool movable;
    Vector2 direction;

    void Update()
    {
        Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
        direction = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed).normalized;
        anim.SetBool("Andando",rb.velocity.magnitude != 0);
        if (movable && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            this.transform.up = direction;
        }
        CheckInteract();
    }
    private void FixedUpdate()
    {
        if (movable)
            rb.velocity = direction;
        else
            rb.velocity = Vector3.zero;
    }
    private void CheckInteract()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit[] raycastInfo; 
            raycastInfo = Physics.CapsuleCastAll(transform.position, transform.position, 0.03f, Vector3.forward, Mathf.Infinity, LayerMask.GetMask("Interact"));
            if(raycastInfo.Length > 0){
                print("hi");
                print(raycastInfo[0].transform.gameObject);
                raycastInfo[0].transform.GetComponent<Iinteractable>().Interact();
            }
        }
    }
}
