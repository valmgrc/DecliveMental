using UnityEngine;

public class BalaController : MonoBehaviour
{

    public float velocidad;
    public bool balaJugador;

    public Vector2 direccion = Vector2.right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 2f); //desaparece la bala despues de 4 segundos para que no se quede vagando
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if( balaJugador && collision.gameObject.tag == "Enemigo") //se asigna que si la bala que se disparó es del jugador y le aitnó a un enemigo (tiene que tener el tag)
        {
            Destroy(collision.gameObject); //Se destruye el enemigo
            Destroy(gameObject);
        }

        if (!balaJugador && collision.CompareTag("Player"))
        {
            GameManager.instance.vidasRestantes();

            WitchController player = collision.GetComponent<WitchController>();

            if (player != null)
            {
                player.Revivir();
            }

            Destroy(gameObject); // destruye la bala
        }



        if (collision.CompareTag("boundary")) //se asigna que si choca con los bordes (Un panel con collider) Se destruye todo lo que lo toque como balas o enemigos
        {
            Destroy(gameObject);
        }
    }

    

}


