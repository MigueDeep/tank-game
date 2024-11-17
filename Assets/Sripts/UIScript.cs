using System.Collections;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI tmpText;  // Asigna aquí el objeto TMP desde el Inspector

    void Start()
    {
        // Inicia la corrutina de parpadeo al iniciar el juego
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        float elapsedTime = 0f;
        float blinkDuration = 3f;  // Duración total de 3 segundos
        bool isVisible = true;

        // Ejecuta el parpadeo mientras el tiempo no haya alcanzado los 3 segundos
        while (elapsedTime < blinkDuration)
        {
            isVisible = !isVisible;  // Alterna visibilidad
            tmpText.enabled = isVisible;  // Apaga/Enciende el texto

            // Espera medio segundo antes de cambiar la visibilidad de nuevo
            yield return new WaitForSeconds(0.5f);

            // Incrementa el tiempo transcurrido
            elapsedTime += 0.5f;
        }

        // Asegúrate de que el texto esté apagado al final
        tmpText.enabled = false;
    }
}
