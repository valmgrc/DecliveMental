using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScreenManager : MonoBehaviour
{
    [Header("Configuración de Escenas")]
    [Tooltip("Asegúrate de que este nombre coincida exactamente con tu escena del menú principal.")]
    [SerializeField] private string MainMenu = "MainMenu";

  
    public void CargarMenuPrincipal()
    {
      
        SceneManager.LoadScene(MainMenu);
    }
}