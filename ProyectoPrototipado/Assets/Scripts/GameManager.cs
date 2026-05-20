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


    public GameObject panelPerder;
    public GameObject panelGanar;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
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

        if (puntos >= puntosNivel)
        {
            if (SceneManager.GetActiveScene().name == "JuegoNivel1") //aqui se asigna que si cumples los puntos requeridos pero estas en la escena del nivel 1, te lleva a la siguiente
            {
                SiguienteNivel();
            }
            else
            {
                Ganar(); 
            }
        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1f;
    }


    public void vidasRestantes()
    {
        vidas--;

        if (vidas <= 0)
        {
            Perder();
        }
    }

    void SiguienteNivel() //metodo para cambiar de escena solo cuando ganas el nivel
    {
      SceneManager.LoadScene("JuegoNivel2");
    }

  
    void Perder()
    {
        Time.timeScale = 0f; //detiene el juego

        if (panelPerder != null)
            panelPerder.SetActive(true);
    }

    void Ganar()
    {
        Time.timeScale = 0f; // ❄️ congela juego

        if (panelGanar != null)
            panelGanar.SetActive(true);
    }

   

}