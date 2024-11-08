using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioAnguloCam : MonoBehaviour
{
    [SerializeField] private GameObject camPlataformas;
    [SerializeField] private GameObject cam1;
    // Start is called before the first frame update
    void Start()
    {
        camPlataformas.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam1.SetActive(false);
            camPlataformas.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam1.SetActive(true);
            camPlataformas.SetActive(false);
        }
    }
}
