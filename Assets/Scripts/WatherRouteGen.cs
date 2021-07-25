using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatherRouteGen : MonoBehaviour
{
    [SerializeField] GameObject next, barco;
    SpriteRenderer sr;

    private void Awake()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Navio>() != null)
        {
            var correct = Vector3.Dot(this.transform.up, barco.transform.up) > 0 ? 1 : -1;
            Instantiate(next, (this.transform.position.y + sr.size.y * correct) * this.transform.up , this.transform.rotation);
        }
    }
}
