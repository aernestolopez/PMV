using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int puntuacion = 0;
    private float tiempo = 0f;
    public static GameManager Instance { get; private set; }
    public bool pausa = false;
    

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Encontrado más de un GameManager de persistencia de datos, destruyendo el más nuevo");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {

        //Si pulsa la tecla K en la escena del menu se incia el juego
        if (SceneManager.GetActiveScene().name=="Menu" && Input.GetKeyDown(KeyCode.K))
        {
            cambiarEscena("Juego");

        }
        //Si pulsa la tecla L en la escena del menu se cierra la aplicacion
        if (SceneManager.GetActiveScene().name == "Menu" && Input.GetKeyDown(KeyCode.L))
        {
            Application.Quit();
        }

        //Si la escena activa es el juego empezamos el contador

        if (SceneManager.GetActiveScene().name=="Juego")
        {
            ContarTiempo();
        }

        //Si no esta en pausa, la escena activa es el menu y pulsamos esc se pausa el juego y se muestra el menu de pausa
        if (!pausa && SceneManager.GetActiveScene().name == "Juego" && Input.GetKeyDown(KeyCode.Escape))
        {
            pausa = true;
            Time.timeScale = 0f;
            Hud.Instance.MostrarInter();

        }
        //Si esta en pausa, la escena activa es el juego y pulsa backspace se reanuda el juego y se oculta el menu de pausa
        if(pausa && SceneManager.GetActiveScene().name == "Juego" && Input.GetKeyDown(KeyCode.Backspace))
        {
            pausa = false;
            Time.timeScale = 1.0f;
            Hud.Instance.OcultarInter();
        }
    }

    //Metodo para cambiar de escenas
    public void cambiarEscena(string nombreEscena)
    {
        //Como el GameManager no se destruye entre escenas debemos controlar que los datos de las variables se reincien
        tiempo = 0f;
        puntuacion = 0;
        Time.timeScale = 1.0f;
        pausa = false;
        //Cambiamos la escena
        SceneManager.LoadScene(nombreEscena, LoadSceneMode.Single);
    }

    //Metodo para sumar puntos
    public void SumarPuntos()
    {
        //Sumamos 1
        puntuacion+=1;
        //Llamamos al metodo del Hud para mostrar la puntuacion
        Hud.Instance.MostrarPuntos(puntuacion);
    }

    //Metodo para contar tiempo
    void ContarTiempo()
    {
        tiempo += Time.deltaTime;
        Hud.Instance.MostrarTiempo(tiempo);

    }
}
