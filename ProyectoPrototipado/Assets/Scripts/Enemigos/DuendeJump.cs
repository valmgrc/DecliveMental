using UnityEngine;

public class DuendeJump : MonoBehaviour
{
    public float rangoActivacion = 2f;

    Transform player;
    Animator anim;
    public int puntosRecolectados = 350; //se declara la cantidad de puntos que vale


    bool Salto = false;

    void Start()
    {
        player = GameObject.Find("Bruja").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distanciaX = Mathf.Abs(player.position.x - transform.position.x);

        if (distanciaX < rangoActivacion && !Salto)
        {
            anim.SetTrigger("Saltar");
            Salto = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        BalaController bala = collision.GetComponent<BalaController>();

        if (bala != null && bala.balaJugador)
        {
            GameManager.instance.SumarPuntos(puntosRecolectados); //y aqui se llama a la variable y al instance del GameManager
            Destroy(gameObject);
        }
    }
}