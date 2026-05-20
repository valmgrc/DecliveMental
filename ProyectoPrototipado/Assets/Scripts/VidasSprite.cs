using UnityEngine;
using System.Collections.Generic;

public class VidasSprite : MonoBehaviour
{
    public SpriteRenderer vidas;
    public List<Sprite> misVidas;

    void Update()
    {
        if (vidas != null && GameManager.instance != null)
        {
            int index = GameManager.instance.vidas - 1;

            if (index >= 0 && index < misVidas.Count)
            {
                vidas.sprite = misVidas[index];
            }
        }
    }
}