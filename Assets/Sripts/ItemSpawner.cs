using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Referencias a los prefabs
    public GameObject bombaPrefab;
    public GameObject vidaPrefab;
    public GameObject municionPrefab;

    private float spawnRangeX = 20f;
    private float spawnRangeY = 20f;
    private float spawnHeight = 0.8f; 
    private float spawnInterval = 4f;

    void Start()
    {
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            // Selecciona un objeto aleatorio
            GameObject itemToSpawn = GetRandomItem();

            // Genera el objeto en una posición aleatoria dentro del rango
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX), 
                spawnHeight, // Coloca la posición Y a la altura especificada
                Random.Range(-spawnRangeY, spawnRangeY)
            );

            Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);

            // Espera antes de generar el siguiente objeto
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Método para seleccionar un prefab aleatorio
    GameObject GetRandomItem()
    {
        float randomValue = Random.Range(0f, 1f); // Valor entre 0 y 1

        if (randomValue < 0.4f) // 40% probabilidad
        {
            return municionPrefab;
        }
        else if (randomValue < 0.7f) // 30% probabilidad
        {
            return bombaPrefab;
        }
        else // 30% probabilidad
        {
            return vidaPrefab;
        }
    }
}
