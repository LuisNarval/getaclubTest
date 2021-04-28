using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    [SerializeField] private float Radious = 1.0f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform CenterTransform;
    [SerializeField] private Vector3 _CenterOfMass;

    private void Update()
    {
        _CenterOfMass = new Vector3(CenterTransform.localPosition.x, CenterTransform.localPosition.y, CenterTransform.localPosition.z);

        rb.centerOfMass = _CenterOfMass;
        rb.WakeUp();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position+transform.rotation*rb.centerOfMass, Radious);
    }

}