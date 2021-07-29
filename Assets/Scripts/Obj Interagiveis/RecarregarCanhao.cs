using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecarregarCanhao : MonoBehaviour, Iinteractable
{
    [SerializeField] Player player;
    public void Interact()
    {
        print("aaewaeaw");
        player.carregandoBola = true;
    }
}
