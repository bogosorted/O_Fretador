using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecarregarCanhao : MonoBehaviour, Iinteractable
{
    [SerializeField] Player player;
    public void Interact()
    {
        player.carregandoBola = true;
    }
}
