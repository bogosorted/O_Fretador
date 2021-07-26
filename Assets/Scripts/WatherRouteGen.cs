using UnityEngine;

public class WatherRouteGen : MonoBehaviour
{
    public bool instaciavel; 

    [SerializeField] GameObject barco;

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
            if (GeraMapa.mapa == 0)
                dist = sr.size.y;
            else
                dist = sr.size.y * 3/2 + 5;// 5 = metade do tamanho da ilha
            Instantiate(GeraMapa.staticMapas[GeraMapa.mapa], dist * GeraMapa.correct * this.transform.up + this.transform.position, this.transform.rotation);
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
