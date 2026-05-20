using UnityEngine;

public class EsfingeAttack : MonoBehaviour
{
    public float velocidad = 3f;


    public int puntosRecolectados = 100; //se declara la cantidad de puntos que vale

    public GameObject balaEnemigo; //declara bala del enemigo
    public Transform bulletPos; //declara la posicion de donde saldra la bala para que tenga coherencia que sala de él
    public float tiempoDisparo = 2f; //velocidad del disarpo
    float timer;

    Rigidbody2D rb;

    Transform target; //Se declara objetivo

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = GameObject.Find("Bruja").transform; //Se asigna el objetivo, el jugador o la bruja
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
        }
    }
}
    

