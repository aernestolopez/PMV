using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public static Hud Instance { get; private set; }
   [SerializeField] private TextMeshProUGUI temporizador;
   [SerializeField] private TextMeshProUGUI puntos;
   [SerializeField] private Button reiniciar;
    [SerializeField] private Button salir;
    [SerializeField] private Button menu;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Encontrado más de un GameManager de persistencia de datos, destruyendo el más nuevo");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        
    }

    //Metodo para mostrar el tiempo transcurrido
    public void MostrarTiempo(float time)
    {
       
        temporizador.text = $"{Mathf.Floor(time / 60):00}:{Mathf.Floor(time % 60):00}:{(time - (int)time) * 100f:00}";  
    }

    //Metodo para mostrar la puntuacion
    public void MostrarPuntos(int punto)
    {
            
            puntos.text = punto.ToString();
    }

    //Metodo para mostrar la interfaz
    public void MostrarInter()
    {
        reiniciar.gameObject.SetActive(true);
        salir.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
    }

    //Metodo para ocultar la interfaz
    public void OcultarInter()
    {
        reiniciar.gameObject.SetActive(false);
        salir.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
    }

    //Metodo para reiniciar el juego
    public void Reiniciar()
    {
        GameManager.Instance.pausa = false;
        
        GameManager.Instance.cambiarEscena("Juego");
    }
    //Metodo para salir de la aplicacion
   public  void Salir()
    {
        Application.Quit();
    }

    //metodo para salir al menu principal
    public void Menu()
    {
        GameManager.Instance.cambiarEscena("Menu");
    }

}
