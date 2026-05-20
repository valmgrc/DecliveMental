using UnityEngine;
using UnityEngine.SceneManagement;

public class Salir : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Welcome Player Screen");
    }    

    public void Saliste()
    {
        Debug.Log("Saliste");
        Application.Quit();

    }
}
