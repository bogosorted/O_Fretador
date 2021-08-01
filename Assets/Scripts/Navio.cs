using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navio : MonoBehaviour
{
    public static bool ancorado = true;

    [SerializeField, Range(0f, 10f)] public float speed;
    public Player pl;
    public GameObject lifeBarFill;
    public Vector3 lifeBarFullSize;

    [SerializeField, Range(0f, 8f)] private int life;
    private List<int> repairsLeft = new List<int>() { 6, 4, 2 };

    void Start()
    {
        if (pl == null)
            pl = transform.GetChild(0).GetComponent<Player>();
        lifeBarFullSize = lifeBarFill.GetComponent<RectTransform>().sizeDelta;
    }

    void FixedUpdate()
    {
        if (!ancorado)
            this.transform.parent.Translate(Vector3.up * speed / 100, Space.Self);
    }
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.F)){
        //     TakeDamage(1);
        // }
        // if(Input.GetKeyDown(KeyCode.G)){
        //    StartCoroutine("RepairBoat");
        // }
    }

    public void TakeDamage(int val)
    {
        life -= val;
        if (life == 0)
            print("u ded");
        else
        {
            if (repairsLeft.Contains((life % 2 == 0) ? life : life + 1))
            {
                print("cria reparo");
                repairsLeft.Remove((life % 2 == 0) ? life : life + 1);
            }
            print(life);
        }
        lifeBarFill.GetComponent<RectTransform>().sizeDelta = new Vector3(lifeBarFullSize.x * ((float)life / 8), lifeBarFullSize.y);
        print((8 / (float)life));
    }

    public IEnumerator RepairBoat()
    {
        Player.movable = false;
        yield return new WaitForSeconds(1);
        Player.movable = true;
        life++;
        lifeBarFill.GetComponent<RectTransform>().sizeDelta = new Vector3(lifeBarFullSize.x * ((float)life / 8), lifeBarFullSize.y);
        print(life);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "rock")
        {
            // this.transform.parent.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(1, (col.transform.position.x < this.transform.parent.position.x) ? 0.5f : -0.5f, 0), col.transform.position, ForceMode.Force);
            // this.transform.parent.GetComponent<Rigidbody>().velocity = transform.parent.position - col.transform.position;
            this.transform.parent.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, (col.transform.position.x > this.transform.parent.position.x) ? 0.7f : -0.7f);
            // this.transform.parent.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, (col.transform.position.x > this.transform.parent.position.x) ? 1 : -1));
            StartCoroutine("Collision");
            print(col.transform.position);
            print("ai ai doeu");
        }
    }

    public IEnumerator Collision()
    {
        var angularSpeed = this.transform.parent.GetComponent<Rigidbody>().angularVelocity * -1;
        yield return new WaitForSeconds(0.2f);
        this.transform.parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        this.transform.parent.GetComponent<Rigidbody>().angularVelocity = angularSpeed;
        yield return new WaitForSeconds(0.2f);
        this.transform.parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        yield return new WaitForSeconds(0.5f);
        this.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }
}
