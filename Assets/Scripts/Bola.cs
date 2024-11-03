using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bola : MonoBehaviour
{
    [Header ("Audio")]
    [SerializeField] AudioClip coleccionables;
    [SerializeField] AudioManager managers;

    [Header("Vida")]
    [SerializeField] TMP_Text textoPuntuacion;
    [SerializeField] int vidas = 100;
    private int puntuacion;

    [Header("Vida")]
    [SerializeField] GameObject virtualCamCenital;
    [SerializeField] GameObject virtualCamNormal;

    [Header("Movimiento")]
    [SerializeField] float fuerza;
    [SerializeField] float distanciaDeteccionSuelo;
    [SerializeField] LayerMask queEsSuelo;
    float velocidad;
    Rigidbody rb;
    private float h, v;
    Vector3 movimiento;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        movimiento.x = h;
        movimiento.y = v;
        Saltar();
       
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
    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DetectarSuelo()) 
        { 
          rb.AddForce(new Vector3(0,1,0).normalized * 3f, ForceMode.Impulse);

        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coleccionables"))
        {
            managers.ReproducirSonido(coleccionables);
            puntuacion++;
            textoPuntuacion.SetText("Puntuación: " + puntuacion);
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("CambioCamara"))
        { 
          virtualCamCenital.SetActive(true);
          virtualCamNormal.SetActive(false);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CambioCamara"))
        {
            virtualCamCenital.SetActive(false);
            virtualCamNormal.SetActive(true);
        }
        if (other.gameObject.CompareTag("Muerte"))
        {

        }
    }
}
