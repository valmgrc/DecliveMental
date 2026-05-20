using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VidasSprite : MonoBehaviour
{

    public SpriteRenderer vidas;
    public List<Sprite> misVidas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        int vidasRestantes = GameManager.instance.vidas;
        vidas.sprite = misVidas[vidasRestantes];
    }
}
