using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject cuadroPausa;
    public GameObject barraVida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PauseGame()
    {
        cuadroPausa.SetActive(true);
        Time.timeScale = 0;
        barraVida.SetActive(false);
    }

    public void ResumeGame()
    {
        cuadroPausa.SetActive(false);
        Time.timeScale = 1;
        barraVida.SetActive(true);
    }
}
