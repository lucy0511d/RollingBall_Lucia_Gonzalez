using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public void EmpezarPartida()
    {
        //Cargar Escena 1
        SceneManager.LoadScene(1);
    }
    public void SalirJuego()
    {
        Application.Quit();
    }
    public void Respawn()
    {
        SceneManager.LoadScene(1);
    }
}
