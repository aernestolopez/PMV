using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField]float velocidad = 20f;
    [SerializeField]float tiempoVida = 4f;
    [SerializeField]Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos el RigidBody
        rb=GetComponent<Rigidbody2D>();
        //Destruimos la bala si ha pasado un tiempo
        Destroy(gameObject, tiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        //Le damos la velocidad y la direccion a la bala
        rb.velocity = transform.up * velocidad;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Si colisiona con el enemigo se destruye el enemigo y la bala
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            //Lamamos al GameManager para sumar puntos
            GameManager.Instance.SumarPuntos();
        }
    }
}
