using UnityEngine;

public class AncoraBehaviour : MonoBehaviour, Iinteractable
{
    Navio navio;
    [SerializeField] AudioSource barulho;
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
            Navio.ancorado = false;
        else
            print("Já ta solto, Zé Mané");
    }
}
