using UnityEngine;

public class WatherRouteGen : MonoBehaviour
{
    public static bool ini = false;
    public bool instaciavel, certo = true;

    [SerializeField] GameObject barco;

    static private Quaternion nextRot;

    float dist;
    SpriteRenderer sr;

    private void Awake()
    {
        sr = this.GetComponent<SpriteRenderer>();
        //for (int i = 1; i < 10; i++)
        //{
        //    var result = direcao[i - 1] + Random.Range(-1, 1);
        //    direcao.Add(result == -1 ? 3 : result == 4 ? 0 : result);
        //}
        //foreach (var i in direcao)
        //{
        //    print(i);
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Navio>() != null && instaciavel)
        {
            instaciavel = false;
            if (GeraMapa.mapa == 0 || !certo)
            {
                dist = sr.size.y;
                nextRot = this.transform.rotation;
            }
            else
            {
                dist = sr.size.y * 3 / 2 + 5;// 5 = metade do tamanho da ilha
                nextRot = Quaternion.identity;
            }

            if (ini && certo)
            {
                Instantiate(GeraMapa.staticMapas[2], dist * GeraMapa.correct * this.transform.up + this.transform.position, nextRot);
                ini = false;
            }
            else
            {

                var novo = Instantiate(GeraMapa.staticMapas[certo ? GeraMapa.mapa : 0], dist * GeraMapa.correct * this.transform.up + this.transform.position, nextRot);

                if (novo.GetComponent<WatherRouteGen>() != null)
                {
                    novo.GetComponent<WatherRouteGen>().certo = certo;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Navio>() != null)
        {
            GeraMapa.aguaAtual = this.gameObject;
        }
    }
}
