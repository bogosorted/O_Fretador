using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RachaduraInteract : MonoBehaviour, Iinteractable
{
    public Navio navio;
    [SerializeField] AudioSource som;
    public void Interact(){
        StartCoroutine(navio.RepairBoat(this.gameObject));
        som.Play();
    }
}
