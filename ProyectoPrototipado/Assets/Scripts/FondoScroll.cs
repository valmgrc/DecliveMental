using UnityEngine;

public class FondoScroll : MonoBehaviour
{
    public float velocidad = 0.2f;
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
            bgRender.material.mainTextureOffset += new Vector2(velocidad * Time.deltaTime, 0);
        }
       
    }
}
