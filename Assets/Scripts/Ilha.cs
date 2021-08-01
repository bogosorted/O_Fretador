using UnityEngine;

public class Ilha : MonoBehaviour
{
    [SerializeField] WatherRouteGen[] aguasFilhas;
    static int ilhaAtual = 0;
    static bool reset = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Navio>() != null)
        {
            GeraMapa.mapa = 0;
            GeraMapa.distancia = GeraMapa.distPadrao;

            if (!aguasFilhas[0].instaciavel)
            {
                if (reset)
                {
                    ilhaAtual = 0;
                    reset = false;
                }
                if (ilhaAtual < GeraMapa.direcao.Count)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        aguasFilhas[i].certo = i == GeraMapa.direcao[ilhaAtual];
                    }
                }
                else if (ilhaAtual == GeraMapa.direcao.Count)
                {
                    GeraMapa.NovaIlha();
                    WatherRouteGen.ini = true;

                    for (int i = 0; i < 4; i++)
                    {
                        aguasFilhas[i].certo = i == GeraMapa.direcao[ilhaAtual];
                    }
                    reset = true;
                }
                print(GeraMapa.direcao[ilhaAtual]);
                ilhaAtual++;
            }

            foreach (var i in aguasFilhas)
                i.instaciavel = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Navio>() != null)
        {
            GeraMapa.mapa = 0;
            GeraMapa.distancia = GeraMapa.distPadrao;
        }
    }
}
