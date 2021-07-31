using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navio : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] public float speed;
   // [SerializeField, Range(0f, 8f)] private int life;
    public bool ancorado;
    public Player pl;
    public GameObject lifeBarFill;
    public Vector3 lifeBarFullSize;
    private List<int> repairsLeft = new List<int>() {6, 4, 2};

    void Start(){
     //   if(pl == null)
      //      pl = transform.GetChild(0).GetComponent<Player>();
     //lifeBarFullSize = lifeBarFill.GetComponent<RectTransform>().sizeDelta;
    }

    void FixedUpdate()
    {
        if (!ancorado)
            this.transform.parent.Translate(Vector3.up * speed / 100, Space.Self);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.F)){
            TakeDamage(1);
        }
        if(Input.GetKeyDown(KeyCode.G)){
          //  StartCoroutine("RepairBoat");
        }
    }

    public void TakeDamage(int val){
        // life -= val;
        // if(life == 0)
        //     print("u ded");
        // else {
        //     if(repairsLeft.Contains((life % 2 == 0) ? life : life + 1)){
        //         print("cria reparo");
        //         repairsLeft.Remove((life % 2 == 0) ? life : life + 1);
        //     }
        //     print(life);
        // }
       // lifeBarFill.GetComponent<RectTransform>().sizeDelta = new Vector3(lifeBarFullSize.x * ((float)life / 8), lifeBarFullSize.y);
        //print((8 / (float)life));
    }

    //public IEnumerator RepairBoat(){
        // pl.movable = false;
        // yield return new WaitForSeconds(1);
        // pl.movable = true;
        // life++;
        // lifeBarFill.GetComponent<RectTransform>().sizeDelta = new Vector3(lifeBarFullSize.x * ((float)life / 8), lifeBarFullSize.y);
        // print(life);
   // }
}
