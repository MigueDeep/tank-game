using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject loadingScreen; // Referencia a la pantalla de carga

    public void Jugar()
    {
        StartCoroutine(LoadSceneWithLoadingScreen(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void Creditos()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    
    public void Salir()
    {
        Application.Quit();
    }

    private IEnumerator LoadSceneWithLoadingScreen(int sceneIndex)
    {
        // Activar la pantalla de carga
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true);
        }

        // Simular un pequeño retraso opcional (para la animación o indicador)
        yield return new WaitForSeconds(0.5f);

        // Cargar la nueva escena
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        // Esperar hasta que la escena esté completamente cargada
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}