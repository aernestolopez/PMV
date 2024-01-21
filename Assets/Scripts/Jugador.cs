using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] Vector2 direccion;
    [SerializeField] float angulo;
    [SerializeField] Transform puntoDisparo;
    [SerializeField] float velocidad = 7f;
    [SerializeField] GameObject bala;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
        direccion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angulo=Mathf.Atan2(direccion.y - transform.position.y, direccion.x - transform.position.x)*Mathf.Rad2Deg-90f;
        transform.localRotation = Quaternion.Euler(0, 0, angulo);
        transform.position = transform.position+ new Vector3(x,y,0);

        //Si pulsa el clic izq dispara una bala
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    //Metodo para disparar
    void Shoot()
    {
        //Se instancia una bala desde prefab
       Instantiate(bala, puntoDisparo.position, puntoDisparo.rotation);
    }
}
