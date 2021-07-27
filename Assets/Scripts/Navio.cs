using UnityEngine;

public class Navio : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] public float speed;
    public bool ancorado;

    void FixedUpdate()
    {
        if (!ancorado)
            this.transform.Translate(Vector3.right * speed / 100, Space.Self);
    }
}
