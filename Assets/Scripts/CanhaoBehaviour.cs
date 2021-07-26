using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoBehaviour : MonoBehaviour, Iinteractable
{
    [SerializeField] private GameObject bolaCanhao;
    private GameObject bolaCanhaoClone;
    [SerializeField] Rigidbody barcoRb;
    [SerializeField] Navio navio;
    public void Interact()
    {
        Atirar();
    }
    private void Atirar()
    {
        bolaCanhaoClone = Instantiate(bolaCanhao, transform.position, transform.rotation);
        Destroy(bolaCanhaoClone, 5f);
        bolaCanhaoClone.GetComponent<BolaCanhao>().navio = navio;
        bolaCanhaoClone.GetComponent<BolaCanhao>().barcoRb = barcoRb;

    }
}
