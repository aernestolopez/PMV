using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] float velocidad = 6f;
    [SerializeField]float tiempoVida = 3.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //El enemigo muere al pasar el tiempo
        Destroy(gameObject, tiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        //Movemos el enemigo de arriba hacia abajo
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);
    }
}
