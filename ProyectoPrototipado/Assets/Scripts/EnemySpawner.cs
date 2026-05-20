using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemigos;

    public float minTiempo = 3f; //tiempo minimo y maximo en el que spawnean los enemigos 
    public float maxTiempo = 5f;

    public float minY = -5f; //Rango del eje y en donde pueden aparecer
    public float maxY = -1f;

    public float spawnX = 12f; //declara que se spawnean fuera de la pantalla

    GameObject ultimoEnemigo;

    float tiempoJuego = 0f; //se declara para contar el tiempo que pasa e ir subiendo dificultad

    void Start()
    {
        StartCoroutine(Spawner());
    }

    void Update()
    {
   
        tiempoJuego += Time.deltaTime; //Va aumentando el tiempo por ende la dificultad o cantidad de enemigos

        minTiempo = Mathf.Clamp(3f - tiempoJuego * 0.05f, 0.8f, 3f); //se asigna que comience lento para despues ir rapido, el mathf lo que hace es asignar un valor minimo y maximo y que no se salga de esos valores
        maxTiempo = Mathf.Clamp(5f - tiempoJuego * 0.05f, 1.5f, 5f);
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            SpawnUnEnemigo();

            float tiempo = Random.Range(minTiempo, maxTiempo);
            yield return new WaitForSeconds(tiempo); // se asigna para que pase un tiempo antes de spawnear otro enemigo
        }
    }

    void SpawnUnEnemigo()
    {
        GameObject enemigo;

        do
        {
            enemigo = enemigos[Random.Range(0, enemigos.Length)]; //El random en la funcion dice que se escoge unn enemigo al azar
        }
        while (enemigo == ultimoEnemigo);

        ultimoEnemigo = enemigo; //Se asigna este enemigo escogido como el ultimo, para que el siguiente no se repita

        float posY;

        if (enemigo.GetComponent<DuendeJump>() != null)
        {
            posY = -3.5f; // aqui se asigna que si es el duende el enemigo se quede en el piso
        }
        else
        {
            posY = Random.Range(minY, maxY);
        }

        Instantiate(enemigo, new Vector3(spawnX, posY, 0f), Quaternion.identity);
    }
}