using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGiratoria : MonoBehaviour
{
    [SerializeField] Vector3 vectorRot1;
    [SerializeField] int velocidadRot;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(vectorRot1 * velocidadRot, ForceMode.VelocityChange);

    }
}
