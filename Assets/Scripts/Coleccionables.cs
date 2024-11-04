using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionables : MonoBehaviour
{
    [SerializeField] Vector3 vectorRot;
    [SerializeField] Vector3 vectorMov;
    [SerializeField] float velocidadrot;
    [SerializeField] float velocidadmov;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Rotate(vectorRot * velocidadrot * Time.deltaTime);
        transform.Translate(vectorMov * velocidadmov * Time.deltaTime, Space.World);
        if (timer >= 1f)
        {
            vectorMov = vectorMov * -1;
            timer = 0;
        }
    }
   
}
