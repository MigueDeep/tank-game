using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject cuadroPausa;
    public GameObject barraVida;
    public AudioSource backgroundMusic; // Componente AudioSource para la música de fondo

    private bool isPaused = false; // Bandera para verificar si el juego está en pausa

    void Start()
    {
        // Asegurarse de que el juego no esté en pausa al inicio
        ResumeGame();
    }

    void Update()
    {
        // Verificar si se presiona la tecla "Esc"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        cuadroPausa.SetActive(true); // Mostrar el menú de pausa
        Time.timeScale = 0; // Detener el tiempo del juego
        barraVida.SetActive(false); // Ocultar la barra de vida
        isPaused = true; // Cambiar el estado a "en pausa"

        // Pausar la música de fondo
        if (backgroundMusic != null)
        {
            backgroundMusic.Pause();
        }
    }

    public void ResumeGame()
    {
        cuadroPausa.SetActive(false); // Ocultar el menú de pausa
        Time.timeScale = 1; // Reanudar el tiempo del juego
        barraVida.SetActive(true); // Mostrar la barra de vida
        isPaused = false; // Cambiar el estado a "en juego"

        // Reanudar la música de fondo
        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause();
        }
    }

    public void goToMenu()
    {
        // Asegurarse de reanudar el tiempo antes de cambiar de escena
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}