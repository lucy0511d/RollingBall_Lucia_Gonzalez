using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField] Vector3 miVector;
    [SerializeField] float velocidad;
    float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(miVector * velocidad * Time.deltaTime);
        if (timer >= 2f)
        {
            miVector = miVector * -1;
            timer = 0;
        }
    }
}
