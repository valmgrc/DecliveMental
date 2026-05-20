using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WitchController : MonoBehaviour
{

    public float velocidad = 5f;
    public GameObject balaPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float velocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        float velocidadY = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;

        transform.position += new Vector3(velocidadX, velocidadY, 0);

        //Vector3 position = transform.position;

        //transform.position = new Vector3(velocidadX + position.x, velocidadY + position.y, position.z);

      

        if(Input.GetKeyDown(KeyCode.Space))
        {

            GameObject b = Instantiate(balaPrefab, transform.position, Quaternion.identity);

            BalaController bala = b.GetComponent<BalaController>();

            bala.balaJugador = true;
            bala.direccion = Vector2.right;

        }
    }
}
