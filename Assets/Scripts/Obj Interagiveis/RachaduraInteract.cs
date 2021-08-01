using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RachaduraInteract : MonoBehaviour, Iinteractable
{
    public Navio navio;
    public void Interact(){
        StartCoroutine(navio.RepairBoat(this.gameObject));
    }
}
