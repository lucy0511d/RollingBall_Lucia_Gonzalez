using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource Spotify;

    private void Start()
    {
       
    }
    public void ReproducirSonidoColeccionable(AudioClip sonidoColeccionable)
    {
        //Ejecuta el clip introducido por parámetro de entrada
        Spotify.PlayOneShot(sonidoColeccionable);
        
    }
    public void ReproducirSonidoCaida(AudioClip sonidoCaida)
    {
        //Ejecuta el clip introducido por parámetro de entrada
        Spotify.PlayOneShot(sonidoCaida);
        
    }
    public void ReproducirSonidoSalto(AudioClip sonidoSalto)
    {
        //Ejecuta el clip introducido por parámetro de entrada
        Spotify.PlayOneShot(sonidoSalto);

    }
   



}
