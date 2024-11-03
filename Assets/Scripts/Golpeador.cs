using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpeador : MonoBehaviour
{
    [SerializeField] Vector3 vectorRot;
    [SerializeField] float fuerzaRot;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(vectorRot * fuerzaRot, ForceMode.Impulse);

    }

    void Update()
    {
        
    }
    
}
