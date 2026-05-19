using UnityEngine;

public class FondoScroll : MonoBehaviour
{
    public float velocidad = 0.1f;
    public float thrust = 0.2f;

    public Renderer bgRender;

    bool juego = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (juego)
        {

            float inputX = Input.GetAxis("Horizontal");
            float velocidadFinal = velocidad;

            if(inputX > 0)
            {
                velocidadFinal += inputX * thrust;
            }


            bgRender.material.mainTextureOffset += new Vector2(velocidadFinal * Time.deltaTime, 0);
        }
       
    }
}
