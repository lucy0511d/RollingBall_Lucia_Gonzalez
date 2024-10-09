using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpeador : MonoBehaviour
{
    [SerializeField] Vector3 vectorRot;
    [SerializeField] float fuerzaRot;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(vectorRot * fuerzaRot, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
