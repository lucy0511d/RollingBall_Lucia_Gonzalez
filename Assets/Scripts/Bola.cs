using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bola : MonoBehaviour
{
    [Header ("Audio")]
    [SerializeField] AudioClip coleccionables;
    [SerializeField] AudioManager managers;

    [Header("Puntuacion")]
    [SerializeField] TMP_Text textoPuntuacion;
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
        textoPuntuacion.SetText("Puntuacion: " + puntuacion);
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
        rb.AddForce (new Vector3 (h, 0, v).normalized * 0.1f, ForceMode.Impulse);

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
            puntuacion += 5;
            textoPuntuacion.SetText("Puntuacion: " + puntuacion);
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("CambioCamara"))
        { 
          virtualCamCenital.SetActive(true);
          virtualCamNormal.SetActive(false);

        }
        if (other.gameObject.CompareTag("Muerte"))
        {
            rb = gameObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                // Detener temporalmente las fisicas de la bola
                rb.velocity = Vector3.zero;
                // Mover al jugador a la posicion inicial
                rb.MovePosition(new Vector3(-0.854f, 1.51f, -27.63f));
                // Reactivar fisicas
                rb.useGravity = true;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CambioCamara"))
        {
            virtualCamCenital.SetActive(false);
            virtualCamNormal.SetActive(true);
        }
       
    }
}
