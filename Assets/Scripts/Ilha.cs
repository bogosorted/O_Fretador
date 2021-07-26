using UnityEngine;

public class Ilha : MonoBehaviour
{
    [SerializeField] WatherRouteGen[] aguasFilhas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Navio>() != null)
        {
            GeraMapa.mapa = 0;
            GeraMapa.distancia = GeraMapa.distPadrao;
            foreach (var i in aguasFilhas)
            {
                i.instaciavel = true;
            }
        }
    }
}
