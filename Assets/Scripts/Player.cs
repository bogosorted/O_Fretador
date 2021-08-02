using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool movable = true;
    public bool carregandoBola;

    [SerializeField] Rigidbody rb;
    [SerializeField, Range(0f, 10f)] float speed, distanciaRampa;
    [SerializeField] Animator anim;
    [SerializeField] GameObject bolaCanhao;

    Vector2 direction;
    RaycastHit[] raycastInfo, hit;

    void Update()
    {
        bolaCanhao.SetActive(carregandoBola);
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        anim.SetBool("Andando", direction != Vector2.zero && movable);

        if (movable && direction != Vector2.zero)
            this.transform.up = direction;

        CheckInteract();
    }
    private void FixedUpdate()
    {
        hit = Physics.CapsuleCastAll(transform.position, transform.position, distanciaRampa, Vector3.forward, Mathf.Infinity, LayerMask.GetMask("Rampa"));

        if (movable)
        {
            if (hit.Length > 0)
                rb.AddForce(Vector3.forward * 30, ForceMode.Force);
            else
                rb.AddForce(Vector3.forward * 300, ForceMode.Force);
            rb.velocity = direction * speed;
        }
        else
            rb.velocity = Vector3.zero;
    }
    private void CheckInteract()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            raycastInfo = Physics.CapsuleCastAll(transform.position, transform.position, distanciaRampa, Vector3.forward, Mathf.Infinity, LayerMask.GetMask("Interact"));
            if (raycastInfo.Length > 0)
            {
                raycastInfo[0].collider.transform.GetComponent<Iinteractable>().Interact();
            }
        }
    }
}
