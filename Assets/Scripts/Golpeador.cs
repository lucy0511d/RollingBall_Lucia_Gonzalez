using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpeador : MonoBehaviour
{
    [SerializeField] Vector3 vectorRot;
    [SerializeField] float fuerzaRot;
    Rigidbody rb;
    //[SerializeField] Vector3 direccionRot;
    //[SerializeField] float velRot;
    //private float timer = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque((vectorRot).normalized * fuerzaRot, ForceMode.VelocityChange);

    }

    void Update()
    {
       // transform.Rotate(direccionRot * velRot * Time.deltaTime);
       // if (timer >= 1f)
       // {
       //     direccionRot = direccionRot * -1;
       //     timer = 0;
       // }
        
    }

}
