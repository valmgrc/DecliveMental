using UnityEngine;

public class EsfingeAttack : MonoBehaviour
{
    public float velocidad = 3f;


    public int puntosRecolectados = 100; //se declara la cantidad de puntos que vale

    public GameObject balaEnemigo; //declara bala del enemigo
    public Transform bulletPos; //declara la posicion de donde saldra la bala para que tenga coherencia que sala de él
    public float tiempoDisparo = 2f; //velocidad del disarpo
    float timer;

    float tiempoPersecucion = 4f;
    float contador = 0f;
    bool persiguiendo = true;


    Rigidbody2D rb;

    Transform target; //Se declara objetivo

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player"); //Se asigna el objetivo, el jugador o la bruja

        if (playerObj != null)
        {
            target = playerObj.transform;
        } 
    }

    void Update()
    {
        contador += Time.deltaTime;

        if (contador >= tiempoPersecucion)
        {
            persiguiendo = false;
        }

        if (target != null && persiguiendo)
        {
            Vector2 direccion = (target.position - transform.position).normalized;
            rb.linearVelocity = direccion * velocidad;
        }
    }

    void FixedUpdate()
    {
        if (!persiguiendo)
        {
            rb.linearVelocity = Vector2.left * velocidad;
        }
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
    

