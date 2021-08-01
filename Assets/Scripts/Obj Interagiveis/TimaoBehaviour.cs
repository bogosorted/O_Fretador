using UnityEngine;

public class TimaoBehaviour : MonoBehaviour, Iinteractable
{
    [SerializeField] Player player;
    public static bool travaAng = false;

    public bool controlando = false;
    GameObject goNavio;
    Navio navio;
    float lastState;

    Quaternion lastAngle;
    void Awake()
    {
        lastState = 0;
        lastAngle = Quaternion.identity;
        goNavio = this.transform.parent.gameObject;
        navio = goNavio.GetComponent<Navio>();
    }

    private void FixedUpdate()
    {
        if (controlando)
            lastState = Mathf.Clamp(lastState + -Input.GetAxisRaw("Horizontal") * 1f / 30, -1, 1);
        if (!Navio.ancorado)
        {
            Quaternion rot = goNavio.transform.parent.rotation;
            goNavio.transform.parent.rotation = new Quaternion(rot.x, rot.y, Mathf.Clamp(rot.z, -0.36f, 0.36f), rot.w);

            lastAngle = goNavio.transform.parent.rotation;

            actualAngulation = (0.137f * lastAngle.z * 10 * (-lastAngle.z * 10) + 2);
            print(actualAngulation);
            if (actualAngulation < 0.225f)
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
            controlando = !controlando;
            Player.movable = !controlando;
        }
    }
}
