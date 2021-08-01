using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navio : MonoBehaviour
{
    public static bool ancorado = true;

    [SerializeField, Range(0f, 10f)] public float speed;
    public Player pl;
    public GameObject lifeBarFill;
    public GameObject[] rachaduras;
    public Vector3 lifeBarFullSize;
    private bool ivulnerable = false;
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
        if(ivulnerable)
            return;
        life -= val;
        if (life == 0)
            print("u ded");
        else
        {
            if (repairsLeft.Contains((life % 2 == 0) ? life : life + 1))
            {
                int toActive = Random.Range(0, 3);
                if(rachaduras[toActive].activeSelf){
                    toActive = (toActive + 1 == 3) ? 0 : toActive + 1;
                    if(rachaduras[toActive].activeSelf){
                        toActive = (toActive + 1 == 3) ? 0 : toActive + 1;
                    }
                }
                rachaduras[toActive].SetActive(true);
                repairsLeft.Remove((life % 2 == 0) ? life : life + 1);
            }
            print(life);
        }
        lifeBarFill.GetComponent<RectTransform>().sizeDelta = new Vector3(lifeBarFullSize.x * ((float)life / 8), lifeBarFullSize.y);
        print((8 / (float)life));
    }

    public IEnumerator RepairBoat(GameObject rachadura){
        Player.movable = false;
        yield return new WaitForSeconds(1);
        Player.movable = true;
        life++;
        lifeBarFill.GetComponent<RectTransform>().sizeDelta = new Vector3(lifeBarFullSize.x * ((float)life / 8), lifeBarFullSize.y);
        rachadura.SetActive(false);
        print(life);
    }

    private void OnTriggerEnter(Collider col)
    {
        print("aaa");
        if(col.tag == "rock"){
            // this.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 diff = this.transform.parent.position - col.transform.position;
            diff = diff.normalized;
            diff = new Vector3(diff.x * 4, -4, 0);
            Destroy(col.gameObject);
            this.transform.parent.GetComponent<Rigidbody>().AddForce(diff, ForceMode.Impulse);
            // this.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
            TakeDamage(2);
            ivulnerable = true;
            StartCoroutine("Collision");
            print("ai ai doeu");
        }
    }

    public IEnumerator Collision()
    {
        yield return new WaitForSeconds(0.3f);
        ivulnerable = false;
        this.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if(transform.GetChild(2).GetComponent<TimaoBehaviour>().controlando)
            transform.GetChild(2).GetComponent<TimaoBehaviour>().Controlar();
    }
}
