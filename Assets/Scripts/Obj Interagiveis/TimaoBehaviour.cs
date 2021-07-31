using UnityEngine;

public class TimaoBehaviour : MonoBehaviour, Iinteractable
{
    [SerializeField] Player player;

    bool controlando = false;
    GameObject goNavio;
    Navio navio;
    float lastState;

    Quaternion lastAngle;
    float deltaAngleX,actualAngulation;
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
            lastState = Mathf.Clamp(lastState + -Input.GetAxisRaw("Horizontal")*1f / 30, -1, 1);
        if (!navio.ancorado)
        {
            goNavio.transform.parent.rotation = Quaternion.Euler(Vector3.forward  * lastState + goNavio.transform.parent.rotation.eulerAngles);
            print(lastState);
            goNavio.transform.localRotation = Quaternion.Euler(new Vector3(0, lastState*actualAngulation * 10  -  180, goNavio.transform.localRotation.eulerAngles.z));
           
            Quaternion rot = goNavio.transform.parent.rotation;
            goNavio.transform.parent.rotation = new Quaternion(rot.x,rot.y,Mathf.Clamp(rot.z,-0.38f,0.38f),rot.w);
           
            deltaAngleX =Mathf.Clamp(Mathf.Abs(goNavio.transform.parent.rotation.z - lastAngle.z)* 300,0,2);
            lastAngle = goNavio.transform.parent.rotation;

            actualAngulation = (0.137f * lastAngle.z*10 * (-lastAngle.z*10)+ 2);
            if (actualAngulation < 0.1f)
                lastState = 0;

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
