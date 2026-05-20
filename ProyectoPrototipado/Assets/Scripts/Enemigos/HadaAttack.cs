using UnityEngine;

public class HadaAttack : MonoBehaviour
{
    public float velocidad = 3f;

    public GameObject balaEnemigo;
    public Transform bulletPos;
    public float tiempoDisparo = 2f;
    float timer;

    public int puntosRecolectados = 100; //se declara la cantidad de puntos que vale


    Rigidbody2D rb;

    Transform target;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            target = playerObj.transform;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (target != null)
        {
            float diferenciaY = Mathf.Abs(target.position.y - transform.position.y);

            if (diferenciaY < 0.5f)
            {
                if (timer > tiempoDisparo)
                {
                    timer = 0;
                    Shoot();
                }
            }
        }

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {

        rb.linearVelocity = Vector2.left * velocidad;
    }

    void Shoot()
    {
        BalaController bala = Instantiate(balaEnemigo, bulletPos.position, Quaternion.identity).GetComponent<BalaController>();

        bala.balaJugador = false;
        bala.direccion = Vector2.left;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BalaController bala = collision.GetComponent<BalaController>();

        if (bala != null && bala.balaJugador)
        {
            GameManager.instance.SumarPuntos(puntosRecolectados); //y aqui se llama a la variable y al instance del GameManager
            Destroy(gameObject);
            Destroy(bala.gameObject);
        }
    }
}


