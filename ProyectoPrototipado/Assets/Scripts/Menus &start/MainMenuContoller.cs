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
        Debug.Log("funciona este boton");
        SceneManager.LoadScene("Pantalla seleccion");
    }

    public void Settings()
    {
        Debug.Log("funciona este boton");
        OptionsPan.alpha = 1;
        OptionsPan.interactable = true;
        OptionsPan.blocksRaycasts = true;
    }

    public void OcultarAjustes()
    {
        OptionsPan.alpha = 0;
        OptionsPan.interactable = false;
        OptionsPan.blocksRaycasts = false;
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
        Application.Quit();
        Debug.Log("funciona este boton");
    }
}
