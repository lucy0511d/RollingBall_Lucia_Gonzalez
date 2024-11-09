

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    [Header("Audio")]
    
    [SerializeField] AudioClip coleccionables;
    [SerializeField] AudioClip salto;
    [SerializeField] AudioClip muerte;
    [SerializeField] AudioManager managers;

    [Header("Puntuacion")]

    [SerializeField] TMP_Text textoPuntuacion;
    private int puntuacion;

    [Header("Camaras")]

    [SerializeField] GameObject virtualCamCenital;
    [SerializeField] GameObject virtualCamNormal;

    [Header("Vida")]

    private int vida = 10;
    [SerializeField] TMP_Text textoVidas;

    [Header("Movimiento")]

    [SerializeField] float fuerza;
    [SerializeField] float distanciaDeteccionSuelo;
    [SerializeField] LayerMask queEsSuelo;
    float velocidad;
    Rigidbody rb;
    private float h, v;
    Vector3 movimiento;

    [Header("Canvas")]
    [SerializeField] GameObject CanvasPuntuacion;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        textoPuntuacion.SetText("Puntuacion: " + puntuacion);
        textoVidas.SetText("Vidas: " + vida);
        //muerte.enabled = false;
        CanvasPuntuacion.SetActive(true);

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
          rb.AddForce(new Vector3(0,1,0).normalized * 3.5f, ForceMode.Impulse);
            managers.ReproducirSonidoSalto(salto);
          
        }
    }
    
   
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coleccionables"))
        {
            managers.ReproducirSonidoColeccionable(coleccionables);
            puntuacion += 5;
            textoPuntuacion.SetText("Puntuacion: " + puntuacion);
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("CambioCamara"))
        { 
          virtualCamCenital.SetActive(true);
          virtualCamNormal.SetActive(false);

        }
        if (other.gameObject.CompareTag("Premio"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(3);

        }

        if (other.gameObject.CompareTag("Muerte"))
        {
            //managers.ReproducirSonidoCaida(muerte);
            //rb = gameObject.GetComponent<Rigidbody>();
            //if(rb != null)
            //{
            //    // Detener temporalmente las fisicas de la bola
            //    rb.velocity = Vector3.zero;
            //    // Mover al jugador a la posicion inicial
            //    rb.MovePosition(new Vector3(-0.854f, 1.51f, -27.63f));
            //    // Reactivar fisicas
            //    rb.useGravity = true;
            //}

            //managers.enabled = false;
            //muerte.enabled = true;
            
            managers.ReproducirSonidoCaida(muerte);
           
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
            CanvasPuntuacion.SetActive(false);
            Destroy(managers);
            SceneManager.LoadScene(2);
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Destroy(gameObject);
            

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trampas"))
        {
            vida--;
            textoVidas.SetText("Vidas: " + vida);
            if (vida <= 0)
            {
                SceneManager.LoadScene(2);
            }

        }
    }
    //using UnityEditor.SearchService;

}
