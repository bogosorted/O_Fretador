using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruidor : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Navio>() != null)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}
