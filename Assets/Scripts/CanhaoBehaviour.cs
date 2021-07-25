using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoBehaviour : MonoBehaviour, Iinteractable
{
    [SerializeField] private GameObject bolaCanhao;
    private GameObject bolaCanhaoClone;
    public void Interact()
    {
        Atirar();
    }
    private void Atirar()
    {
        bolaCanhaoClone = Instantiate(bolaCanhao, transform.position, transform.rotation);
        Destroy(bolaCanhaoClone, 5f);
    }
}
