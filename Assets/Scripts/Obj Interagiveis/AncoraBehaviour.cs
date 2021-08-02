using UnityEngine;

public class AncoraBehaviour : MonoBehaviour, Iinteractable
{
    Navio navio;
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
        if (Navio.ancorado)
            Navio.ancorado = false;
        else
            print("Já ta solto, Zé Mané");
    }
}
