using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource Spotify;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReproducirSonido(AudioClip sonidoColeccionable)
    {
        //Ejecuta el clip introducido por parámetro de entrada
        Spotify.PlayOneShot(sonidoColeccionable);
    }
}
