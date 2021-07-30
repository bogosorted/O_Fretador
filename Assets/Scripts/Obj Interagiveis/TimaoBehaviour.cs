using UnityEngine;

public class TimaoBehaviour : MonoBehaviour, Iinteractable
{
    [SerializeField] Player player;

    bool controlando = false;
    GameObject goNavio;
    Navio navio;
    float lastState;
    void Awake()
    {
        lastState = 0;
        goNavio = this.transform.parent.gameObject;
        navio = goNavio.GetComponent<Navio>();
    }
    private void FixedUpdate()
    {

        if (controlando)
            lastState = Mathf.Clamp(lastState + -Input.GetAxisRaw("Horizontal") / 30, -1, 1);
        if (!navio.ancorado)
        {
            goNavio.transform.parent.rotation = Quaternion.Euler(Vector3.forward * lastState + goNavio.transform.parent.rotation.eulerAngles);
            goNavio.transform.localRotation = Quaternion.Euler(new Vector3(0, lastState * 10 - 180, goNavio.transform.localRotation.eulerAngles.z));
        }
    }
    public void Interact()
    {
        Controlar();
    }
    public void Controlar()
    {
        if (!navio.ancorado)
        {
            controlando = !controlando;
            player.movable = !controlando;
        }
    }
}
