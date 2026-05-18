using UnityEngine;

public class Personalizacion : MonoBehaviour
{

    public GameObject spriteActual;


    public GameObject bruja01;
    public GameObject bruja02;
    public GameObject bruja03;


    public void Start()
    {
        bruja01.SetActive(true);
        bruja02.SetActive(false);
        bruja03.SetActive(false);
    }

    // Update is called once per frame
    public void Click()
    {
        if (spriteActual)
        {
            spriteActual.SetActive(true);
        }
        
        bruja01.SetActive(false);
        bruja02.SetActive(false);
        bruja03.SetActive(false);
    }
}
