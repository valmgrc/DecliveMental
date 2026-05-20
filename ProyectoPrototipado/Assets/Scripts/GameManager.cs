using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int puntos = 0; //se declara que los puntos al comenzar son 0
    public int puntosNivel = 2000; //se declara la cantidad de puntos requeridos para pasar el nivel 1
    public int vidas = 3; //Se declara la variable de cuantas vidas/intentos tenemos
    public TextMeshProUGUI textoPuntaje;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; //Guarda el controlador del puntaje para que otros objetos puedan acceder
            DontDestroyOnLoad(gameObject); //
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    void Start()
    {
        textoPuntaje.text = "" + puntos; //aqui se asigna al principio para que muestre los puntos, que son 0
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        textoPuntaje.text = "" + puntos; //aqui ya se asigna para que vaya sumando la cantidad

        if (puntos >= puntosNivel) //aqui se asigna que la cantidad de puntos al ser los mismos ya pasas de nivel
        {
            SiguienteNivel();
        }

    }

    public void vidasRestantes()
    {
        vidas--;

        if (vidas <= 0)
        {
            //SceneManager.LoadScene("escenadeperderlol");
        }
    }

    void SiguienteNivel() //metodo para cambiar de escena solo cuando ganas el nivel
    {
      SceneManager.LoadScene("JuegoNivel2");
    }

    void Ganar() //metodo para cambiar de escena solo cuando ganas el nivel
    {
        SceneManager.LoadScene("JuegoNivel2");
    }

    void Perder() //metodo para cambiar de escena solo cuando ganas el nivel
    {
        SceneManager.LoadScene("JuegoNivel2");
    }
}