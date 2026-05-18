using UnityEngine;

public class BalaController : MonoBehaviour
{

    public float velocidad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemigo");
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "boundary")
        {
            Destroy(collision.gameObject);
        }
    }
}
