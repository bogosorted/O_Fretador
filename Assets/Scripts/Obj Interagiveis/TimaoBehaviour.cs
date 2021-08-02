using UnityEngine;

public class TimaoBehaviour : MonoBehaviour, Iinteractable
{
    public bool controlando = false;

    [SerializeField] Player player;
    [SerializeField] float voltinha;

    GameObject goNavio;
    Navio navio;
    float lastState;
    Quaternion lastAngle;
    float actualAngulation;
    [SerializeField] GameObject space;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            space.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            space.SetActive(false);
    }

    void Awake()
    {
        lastState = 0;
        goNavio = this.transform.parent.gameObject;
        navio = goNavio.GetComponent<Navio>();
    }
    private void FixedUpdate()
    {
        if (controlando)
            lastState = Mathf.Clamp(lastState - Input.GetAxisRaw("Horizontal") / 30, -1, 1);
        if (!Navio.ancorado)
        {
            goNavio.transform.parent.rotation = Quaternion.Euler(Vector3.forward * lastState + goNavio.transform.parent.rotation.eulerAngles);
            goNavio.transform.localRotation = Quaternion.Euler(new Vector3(0, lastState * 10 - 180, goNavio.transform.localRotation.eulerAngles.z));
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if (Mathf.Abs(lastState) - voltinha > voltinha)
                lastState += (lastState != 0 ? lastState > 0 ? -voltinha : voltinha : 0);
            else
                lastState = 0;
        }
    }
    public void Interact()
    {
        Controlar();
    }
    public void Controlar()
    {
        if (!Navio.ancorado)
        {
            space.SetActive(controlando);
            controlando = !controlando;
            Player.movable = !controlando;
        }
    }
}