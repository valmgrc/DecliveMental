using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Necesario para interactuar con los Sliders
using TMPro;           // Necesario para controlar el tamaño de la letra

public class MainMenuContoller : MonoBehaviour
{
    [Header("Paneles")]
    public CanvasGroup OptionsPan;

    [Header("Configuración de Audio")]
    public Slider volumeSlider;

    [Header("Configuración de Texto")]
    public Slider fontSizeSlider;
    // Arrastra aquí todos los textos del juego que quieras que cambien de tamaño
    public TMP_Text[] textosDelJuego;

    [Header("Configuración de Escenas")]
    // Cambiamos el nombre aquí para que coincida exactamente con tu escena de Unity
    [SerializeField] private string Peronalizacion = "Personalizacion";

    private void Start()
    {
        OcultarAjustes();

        if (volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume;
            volumeSlider.onValueChanged.AddListener(CambiarVolumen);
        }

        if (fontSizeSlider != null)
        {
            fontSizeSlider.minValue = 10;
            fontSizeSlider.maxValue = 35;
            fontSizeSlider.value = 12; // Tamaño por defecto
            fontSizeSlider.onValueChanged.AddListener(CambiarTamañoLetra);
        }
    }

    public void Play()
    {
        Debug.Log("Botón Jugar presionado. Llamando a la pantalla de carga...");

        // Al estar en la misma escena, va a encontrar el SceneLoader al instante
        if (SceneLoader.Instance != null)
        {
            SceneLoader.Instance.CargarEscena(Peronalizacion);
        }
        else
        {
            // Respaldo por si acaso haces pruebas con el SceneLoader apagado
            Debug.LogWarning("SceneLoader no encontrado en el MainMenu. Cargando directo.");
            SceneManager.LoadScene(Peronalizacion);
        }
    }

    public void Settings()
    {
        Debug.Log("Abriendo panel de ajustes...");
        if (OptionsPan != null)
        {
            OptionsPan.alpha = 1;
            OptionsPan.interactable = true;
            OptionsPan.blocksRaycasts = true;
        }
    }

    public void OcultarAjustes()
    {
        if (OptionsPan != null)
        {
            OptionsPan.alpha = 0;
            OptionsPan.interactable = false;
            OptionsPan.blocksRaycasts = false;
        }
    }

    public void CambiarVolumen(float valor)
    {
        AudioListener.volume = valor;
    }

    public void CambiarTamañoLetra(float nuevoTamaño)
    {
        foreach (TMP_Text texto in textosDelJuego)
        {
            if (texto != null)
            {
                texto.fontSize = nuevoTamaño;
            }
        }
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}