using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Video;

public class TutorialController : MonoBehaviour
{
 
    public float tiempoEspera = 3f; //tiempo para que cambie de escena si no hay video
    public VideoPlayer videoPlayer; //video

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += FinDelVideo; //Cuando se llega al final del video
        }
        else
        {
            StartCoroutine(EsperarYContinuar());
        }
    }

    IEnumerator EsperarYContinuar() //metodo que permite detener el juego en un frame en especifico 
    {
        yield return new WaitForSeconds(tiempoEspera); //yield pausa el codigo para ejecutar dicha funcion
        IrAlJuego(); //te lleva al juego
    }

    void FinDelVideo(VideoPlayer vp)
    {
        IrAlJuego();
    }

    void IrAlJuego()
    {
        SceneManager.LoadScene("JuegoNivel1");
    }
}
   

