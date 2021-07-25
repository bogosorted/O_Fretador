using UnityEngine;

public class AncoraBehaviour : MonoBehaviour, Iinteractable
{
    Navio navio;
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
        if (navio.ancorado)
            navio.ancorado = false;
        else
            print("Já ta solto, Zé Mané");
    }
}
