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
        if (Navio.ancorado)
            Navio.ancorado = false;
        else
            print("Já ta solto, Zé Mané");
    }
}
