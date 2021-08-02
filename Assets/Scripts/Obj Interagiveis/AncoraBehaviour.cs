using UnityEngine;

public class AncoraBehaviour : MonoBehaviour, Iinteractable
{
    Navio navio;
    [SerializeField] GameObject space;
    [SerializeField] AudioSource barulho;
    [SerializeField] GameObject anchor,chain;


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


    private void Awake()
    {
        navio = this.transform.GetComponentInParent<Navio>();
    }
    public void Interact()
    {
        PuxarAncora();
    }
    private void PuxarAncora()
    {
        barulho.Play();
        if (Navio.ancorado)
        {
            Navio.ancorado = false;
            anchor.SetActive(true);
            chain.SetActive(false);
        }
        else
            print("Já ta solto, Zé Mané");
    }
}
