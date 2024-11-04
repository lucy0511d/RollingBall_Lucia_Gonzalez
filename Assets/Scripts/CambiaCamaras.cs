using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaCamaras : MonoBehaviour
{
    [SerializeField] private GameObject cam1;
    [SerializeField] private GameObject camCenital;

    private void OnTriggerEnter (Collider other)
    {
      if (other.gameObject.CompareTag("Player"))
      {
            cam1.SetActive(false);
            camCenital.SetActive(true);
      }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam1.SetActive(true);
            camCenital.SetActive(false);
        }
    }

}
