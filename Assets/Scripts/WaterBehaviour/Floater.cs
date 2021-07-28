using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;
    [SerializeField]private float depthBeforeSubmerged = 1f, displacementAmount = 3f, waterDrag = 2f, waterAngularDrag = 2f;
    [SerializeField, Min(1)]private int floaterCount = 1;

    private void FixedUpdate() {
        rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);

        float waveHeigth = WaveManager.instance.GetWaveHeight(transform.position.x);
        if(transform.position.y < waveHeigth){
            float displacementMultipler = Mathf.Clamp01((waveHeigth - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementAmount, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMultipler * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultipler * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}