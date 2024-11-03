using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ParedCubos : MonoBehaviour
{
    [SerializeField] private Rigidbody[] rbs;
    
    private float timer = 0f;
    private bool iniciarCuenta = false;
    void Update()
    {
       if (iniciarCuenta)
       {
            timer += 1 * Time.unscaledDeltaTime;
            for (int i = 0; i < rbs.Length; i++) 
            {
                rbs[i].useGravity = true;

            }
       }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0.2f;
        }
    }
}
