using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource Spotify;
    [SerializeField] AudioClip caida;

    private void Start()
    {
        
    }
    public void ReproducirSonidoColeccionable(AudioClip sonidoColeccionable)
    {
        //Ejecuta el clip introducido por parámetro de entrada
        Spotify.PlayOneShot(sonidoColeccionable);
        
    }

    //public void ReproducirSonidoFondo(AudioClip sonidoFondo)
    //{
    //    Spotify.PlayOneShot(sonidoFondo);
    //}
}
