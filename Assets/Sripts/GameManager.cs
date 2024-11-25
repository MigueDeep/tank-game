using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Para manejar elementos de UI

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton para acceder desde otros scripts
    

    private int enemiesDestroyed = 0; // Contador de enemigos destruidos
    public int totalEnemies = 10; // Número total de enemigos

    public GameObject winPanel; 
    public GameObject barraVida;

    void Awake()
    {
        // Configuración del Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Asegurarse de que el panel de ganar esté desactivado al inicio
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    public void EnemyDestroyed()
    {
        enemiesDestroyed++;

        // Verifica si todos los enemigos han sido destruidos
        if (enemiesDestroyed >= totalEnemies)
        {
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        if (winPanel != null)
        {
            barraVida.SetActive(false);
            winPanel.SetActive(true); // Activa el panel de ganar
        }
        Debug.Log("¡Ganaste el juego!");
    }
}
