using UnityEngine;

public class BalaController : MonoBehaviour
{

    public float velocidad;
    public bool balaJugador;

    public Vector2 direccion = Vector2.right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if( balaJugador && collision.gameObject.tag == "Enemigo")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (!balaJugador && collision.CompareTag("Player"))
        {
            Debug.Log("se muere");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.CompareTag("boundary"))
        {
            Destroy(gameObject);
        }
    }

}
