using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMenu : MonoBehaviour
{
    [SerializeField] AudioSource Spotify;
    public void ReproducirSonidoBoton(AudioClip sonidoBoton)
    {
        //Ejecuta el clip introducido por par�metro de entrada
        Spotify.PlayOneShot(sonidoBoton);

    }
}
