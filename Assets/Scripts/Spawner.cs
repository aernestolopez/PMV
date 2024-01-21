using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemigo;
    
    void Start()
    {
        StartCoroutine(SpawnerEnemigos());
    }

    //Cada 3 segundos se crean enemigos
    IEnumerator SpawnerEnemigos()
    {
        while (true)
        {
            Vector3 spawn=new Vector3(Random.Range(-18f, 17f), 10f, 0f);
            Instantiate(enemigo, spawn, Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }
}
