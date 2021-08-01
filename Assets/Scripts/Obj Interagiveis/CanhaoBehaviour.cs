using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoBehaviour : MonoBehaviour, Iinteractable
{
    [SerializeField] private GameObject bolaCanhao;
    [SerializeField] AudioSource som;
    [SerializeField] private Player player;
    private GameObject bolaCanhaoClone;
    [SerializeField] Rigidbody barcoRb;
    [SerializeField] Navio navio;
    private bool ativado;
    
    public void Interact()
    {
        if(ativado)
        {
            Atirar();
            som.Play();
            ativado = false;
        }
        else if(player.carregandoBola)
        {
            print("CARREGANDO!");
            ativado = true;
            player.carregandoBola = false;
        }
    }
    private void Atirar()
    {
        bolaCanhaoClone = Instantiate(bolaCanhao, transform.position, transform.rotation);
        Destroy(bolaCanhaoClone, 5f);
        bolaCanhaoClone.GetComponent<BolaCanhao>().navio = navio;
        bolaCanhaoClone.GetComponent<BolaCanhao>().barcoRb = barcoRb;

    }
}
