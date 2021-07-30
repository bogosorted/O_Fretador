using System.Collections.Generic;
using UnityEngine;

public class GeraMapa : MonoBehaviour
{
    public static float distancia, correct, distPadrao;
    public static GameObject aguaAtual;
    public static GameObject[] staticMapas;

    [SerializeField] float distanciaSegundos10;
    [SerializeField] GameObject barco, start;
    [SerializeField] GameObject[] mapas;
    
    List<int> direcao = new List<int>();
    Navio navio;

    public static int mapa;
    void Awake()
    {
        staticMapas = mapas;
        GeraMapa.aguaAtual = start;
        distancia = distanciaSegundos10 * 10;
        distPadrao = distancia;
        direcao.Add(Random.Range(0, 3));// 0 == esq, 1 == frente, 2 == direi, 3 == baix
        navio = barco.GetComponent<Navio>();
    }

    // Update is called once per frame
    void Update()
    {
        correct = Vector3.Dot(aguaAtual.transform.up, barco.transform.right) > 0 ? 1 : -1;
        if (!navio.ancorado)
            distancia -= navio.speed * correct * Time.deltaTime;
        if (distancia <= 0)
            mapa = 1;
    }
}
