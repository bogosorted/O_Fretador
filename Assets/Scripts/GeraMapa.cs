using System.Collections.Generic;
using UnityEngine;

public class GeraMapa : MonoBehaviour
{
    public static Vector3 initPosition;
    public static Quaternion initRotation;
    public static List<int> direcao = new List<int>(); // 0 == esq, 1 == frente, 2 == direi, 3 == baix
    public static float distancia, correct, distPadrao;
    public static GameObject aguaAtual, barcoStatic;
    public static GameObject[] staticMapas;
    public static int mapa;

    [SerializeField] float distanciaSegundos10;
    [SerializeField] GameObject barco, start;
    [SerializeField] GameObject[] mapas;
    
    Navio navio;

    void Awake()
    {
        initPosition = barco.transform.parent.transform.position;
        initRotation = barco.transform.parent.transform.rotation;
        staticMapas = mapas;
        GeraMapa.aguaAtual = start;
        distancia = distanciaSegundos10 * 10;
        distPadrao = distancia;
        direcao.Add(1);
        navio = barco.GetComponent<Navio>();
        barcoStatic = barco;
    }

    // Update is called once per frame
    void Update()
    {
        correct = Vector3.Dot(aguaAtual.transform.up, barco.transform.right) > 0 ? 1 : -1;
        if (!Navio.ancorado)
            distancia -= navio.speed * correct * Time.deltaTime;
        if (distancia <= 0)
            mapa = 1;
    }

    public static void NovaIlha()
    {
        var result = direcao[direcao.Count - 1] + Random.Range(-1, 1);
        direcao.Add(result == -1 ? 3 : result == 4 ? 0 : result);
    }
}
