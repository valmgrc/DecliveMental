using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }
    public AudioSource audioDeCarga;

    [Header("UI Componentes")]
    [SerializeField] private CanvasGroup loadingPanel;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private CanvasGroup animacionSprite;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // --- NUEVO: Aseguramos que el audio empiece apagado ---
        if (audioDeCarga != null) audioDeCarga.Stop();

        OcultarPantallaCarga();
    }

    public void CargarEscena(string nombreEscena)
    {
        StartCoroutine(CargarAsincronamente(nombreEscena));
    }

    private IEnumerator CargarAsincronamente(string nombreEscena)
    {
        if (loadingPanel != null)
        {
            loadingPanel.alpha = 1;
            loadingPanel.interactable = true;
            loadingPanel.blocksRaycasts = true;
        }

        // Ahora sí, encendemos el audio solo cuando empieza la carga
        if (audioDeCarga != null) audioDeCarga.Play();

        if (loadingBar != null) loadingBar.value = 0;
        if (progressText != null) progressText.text = "0%";

        if (animacionSprite != null)
        {
            animacionSprite.alpha = 1;
        }

        yield return new WaitForSecondsRealtime(0.1f);

        AsyncOperation operacion = SceneManager.LoadSceneAsync(nombreEscena);

        while (!operacion.isDone)
        {
            float progresoClampeado = Mathf.Clamp01(operacion.progress / 0.9f);

            if (loadingBar != null) loadingBar.value = progresoClampeado;
            if (progressText != null) progressText.text = (progresoClampeado * 100f).ToString("F0") + "%";

            yield return null;
        }

        // Detenemos el audio al terminar
        if (audioDeCarga != null) audioDeCarga.Stop();

        OcultarPantallaCarga();
    }

    private void OcultarPantallaCarga()
    {
        if (loadingPanel != null)
        {
            loadingPanel.alpha = 0;
            loadingPanel.interactable = false;
            loadingPanel.blocksRaycasts = false;
        }

        if (animacionSprite != null)
        {
            animacionSprite.alpha = 0;
        }
    }
}