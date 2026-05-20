using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemigos; //array de los enemigos que hay

    public float minTiempo = 6f;
    public float maxTiempo = 9f;

    public float minY = -4f;
    public float maxY = 4f;

    public float spawnX = 10f;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            SpawnEnemigos();

            float tiempo = Random.Range(minTiempo, maxTiempo);
            yield return new WaitForSeconds(tiempo);
        }
    }

    void SpawnEnemigos()
    {
        int cantidad = Random.Range(1, 3);

        for (int i = 0; i < cantidad; i++)
        {
            GameObject enemigo = enemigos[Random.Range(0, enemigos.Length)];

            float posY;

          
            if (enemigo.GetComponent<DuendeJump>() != null)
            {
                posY = -174f; 
            }
            else
            {
                posY = Random.Range(minY, maxY);
            }

            Instantiate(enemigo, new Vector3(spawnX, posY, 0f), Quaternion.identity);
        }
    }
}
