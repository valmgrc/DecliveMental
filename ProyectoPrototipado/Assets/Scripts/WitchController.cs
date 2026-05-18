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

        Vector3 position = transform.position;

        transform.position = new Vector3(velocidadX + position.x, velocidadY + position.y, position.z);

        //bala

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("bala");
            Instantiate(balaPrefab,transform.position, Quaternion.identity);
        }
    }
}
