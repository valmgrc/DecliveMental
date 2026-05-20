using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DragonChaser : MonoBehaviour
{

    public float velocidad = 20f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    public bool balaJugador;

    float tiempoPersecucion = 3f;
    float contador = 0f;
    bool persiguiendo = true;


    public int puntosRecolectados = 600; //se declara la cantidad de puntos que vale

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            target = playerObj.transform;
        }
    }

    // Update is called once per frame
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

