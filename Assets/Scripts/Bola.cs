using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    Vector3 movimiento;
    // [SerializeField] TMP_Text textoPuntuacion;
    [SerializeField] float fuerza;
    [SerializeField] float distanciaDeteccionSuelo;
    [SerializeField] LayerMask queEsSuelo;
    float velocidad;
    Rigidbody rb;
    private float h, v;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        movimiento.x = h;
        movimiento.y = v;
       
    }
    bool DetectarSuelo()
    { 
        bool resultado = Physics.Raycast(transform.position, new Vector3(0, -1, 0), distanciaDeteccionSuelo, queEsSuelo);
        return resultado;
    }
    private void FixedUpdate()
    {
        rb.AddForce (new Vector3 (h, 0, v).normalized * 0.1f,ForceMode.Impulse);

        rb.AddForce(new Vector3(h, 0, v).normalized * 0.1f, ForceMode.Force);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coleccionable"))
        {
            Destroy(other.gameObject);
        }
    }
}
