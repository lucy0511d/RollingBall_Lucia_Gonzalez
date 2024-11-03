using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource Spotify;
    
    public void ReproducirSonido(AudioClip sonidoColeccionable)
    {
        //Ejecuta el clip introducido por parámetro de entrada
        Spotify.PlayOneShot(sonidoColeccionable);
    }
}
