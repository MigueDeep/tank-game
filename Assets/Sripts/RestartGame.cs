using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importa el namespace para manejar escenas

public class RestartGame : MonoBehaviour
{
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Método para reiniciar el juego
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void goToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
