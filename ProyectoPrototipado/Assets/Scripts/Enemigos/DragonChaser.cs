using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DragonChaser : MonoBehaviour
{

    public float velocidad = 20f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            target = GameObject.Find("Bruja").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                moveDirection = direction;

                //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                //rb.rotation = angle;
            }
    }

        private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * velocidad;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("golpeadito");
        }
    }
}
