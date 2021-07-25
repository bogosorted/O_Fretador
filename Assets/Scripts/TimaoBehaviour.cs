using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimaoBehaviour : MonoBehaviour, Iinteractable
{
    [SerializeField] Player player;
    bool controlando = false;
    GameObject goNavio;
    Navio navio;
    void Awake()
    {
        goNavio = this.transform.parent.gameObject;
        navio = goNavio.GetComponent<Navio>();
    }
    private void FixedUpdate()
    {
        if (controlando)
        {
            var teste = Vector3.one;
            teste += Vector3.right;
            goNavio.transform.rotation = Quaternion.Euler(-Vector3.forward * Input.GetAxis("Horizontal") + goNavio.transform.rotation.eulerAngles); 
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
            print(player.movable);
            controlando = !controlando;
            player.movable = !controlando;
            print(player.movable);
        }
    }
}
