using UnityEngine;

public class EsfingeAttack : MonoBehaviour
{
    public Sprite balaEnemigo;
    public Transform bulletPos;

    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(balaEnemigo, bulletPos.position, Quaternion.identity);
    }
}
