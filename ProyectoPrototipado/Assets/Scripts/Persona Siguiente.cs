using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonaSiguiente : MonoBehaviour
{


    [SerializeField] private string Tutorial = "Tutorial";
    public void Comenzar()
    {

        SceneManager.LoadScene(Tutorial);

    }
        

}
