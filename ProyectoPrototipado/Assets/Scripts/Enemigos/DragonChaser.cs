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
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = angle;  aqui solo girar en x para voltear a ver a usuario
        }
    }

    private void FixedUpdate() //se ejecuta en intervalos independientes a diferencia del update que lo llama en cada fotograma
    {
        rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * velocidad;
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
            }
        }
    }

