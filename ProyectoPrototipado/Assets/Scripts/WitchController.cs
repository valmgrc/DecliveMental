using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WitchController : MonoBehaviour
{

    public float velocidad = 5f; //velocidad de la volada
    public GameObject balaPrefab;

    public SpriteRenderer spriteR;
    public Sprite[] brujasSprite;

    bool invencible = false; //para que no muera seguido


    //Vector3 posicionInicial;

    void Start()
    {
        //posicionInicial = transform.position;

        int id = PlayerPrefs.GetInt("BrujitaSeleccionada", 0);

        Debug.Log("ID: " + id);
        Debug.Log("Sprites length: " + brujasSprite.Length);

        if (spriteR == null) Debug.Log("SpriteRenderer NULL");

        if (id < 0 || id >= brujasSprite.Length)
        {
            id = 0;
        }

        spriteR.sprite = brujasSprite[id];
    }


    // Update is called once per frame
    void Update()
    {

        float velocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        float velocidadY = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;

        transform.position += new Vector3(velocidadX, velocidadY, 0);

        //Vector3 position = transform.position;

        //transform.position = new Vector3(velocidadX + position.x, velocidadY + position.y, position.z);



        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject b = Instantiate(balaPrefab, transform.position, Quaternion.identity);

            BalaController bala = b.GetComponent<BalaController>();

            bala.balaJugador = true;
            bala.direccion = Vector2.right;

        }
    }

    public void Revivir()
    {
        if (invencible) return;

        invencible = true;

        Debug.Log("Daño recibido");

        Invoke("QuitarInvencible", 1f); //se mantiene

    }

    void QuitarInvencible()
    {
        invencible = false;
    }

}
