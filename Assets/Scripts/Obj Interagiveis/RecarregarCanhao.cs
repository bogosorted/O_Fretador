using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecarregarCanhao : MonoBehaviour, Iinteractable
{
    [SerializeField] Player player;
    [SerializeField] GameObject space;
     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            space.SetActive(true);
    }
      private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
            space.SetActive(false);
    }
    public void Interact()
    {
        print("aaewaeaw");
        player.carregandoBola = true;
    }

}
