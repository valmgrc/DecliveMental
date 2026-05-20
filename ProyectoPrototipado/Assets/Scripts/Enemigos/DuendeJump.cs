using UnityEngine;

public class DuendeJump : MonoBehaviour
{
    public float rangoActivacion = 2f;

    Transform player;
    Animator anim;
    public int puntosRecolectados = 350; //se declara la cantidad de puntos que vale
    public float velocidad = 3f;
    Rigidbody2D rb;


    bool Salto = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
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

    void FixedUpdate()
    {
        rb.linearVelocity = Vector2.left * velocidad;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.vidasRestantes();

            WitchController player = collision.GetComponent<WitchController>();

            if (player != null)
            {
                player.Revivir();
            }

            Destroy(gameObject);
        }

        BalaController bala = collision.GetComponent<BalaController>();

        if (bala != null && bala.balaJugador)
        {
            GameManager.instance.SumarPuntos(puntosRecolectados); //y aqui se llama a la variable y al instance del GameManager
            Destroy(gameObject);
            Destroy(bala.gameObject);
        }


    }
}