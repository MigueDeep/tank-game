using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // Referencias a los prefabs
    public GameObject bombaPrefab;
    public GameObject vidaPrefab;
    public GameObject monedasPrefab;
    public GameObject municionPrefab;
    public GameObject escudoPrefab;

    // Área donde se pueden generar los objetos
    public float spawnRangeX = 10f;
    public float spawnRangeY = 10f;

    // Intervalo de tiempo entre cada generación de objetos
    public float spawnInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Comienza a generar objetos aleatorios
        StartCoroutine(SpawnItems());
    }

    // Coroutine para generar objetos en intervalos
    IEnumerator SpawnItems()
    {
        while (true)
        {
            // Selecciona un objeto aleatorio
            GameObject itemToSpawn = GetRandomItem();

            // Genera el objeto en una posición aleatoria dentro del rango
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0f, Random.Range(-spawnRangeY, spawnRangeY));
            Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);

            // Espera antes de generar el siguiente objeto
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Método para seleccionar un prefab aleatorio
    GameObject GetRandomItem()
    {
        int randomIndex = Random.Range(0, 5); // Hay 5 tipos de objetos
        switch (randomIndex)
        {
            case 0:
                return bombaPrefab;
            case 1:
                return vidaPrefab;
            case 2:
                return monedasPrefab;
            case 3:
                return municionPrefab;
            case 4:
                return escudoPrefab;
            default:
                return null;
        }
    }
}
