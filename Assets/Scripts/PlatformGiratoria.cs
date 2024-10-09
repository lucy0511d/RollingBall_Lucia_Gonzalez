using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGiratoria : MonoBehaviour
{
    [SerializeField] Vector3 vectorRot1;
    [SerializeField] Vector3 vectorRot2;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(vectorRot1 * 500, ForceMode.VelocityChange);
        rb.AddTorque(vectorRot2 * 500, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
