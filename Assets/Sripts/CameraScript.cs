using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencia al jugador (asigna tu jugador en el Inspector)
    public Vector3 offset = new Vector3(0f, 1.5f, -3f); // Offset para la posición de la cámara
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el movimiento de la cámara
    public float maxRotationAngle = 45f; // Límite máximo de rotación en grados (hacia los lados)

    private Vector3 initialOffset; // Para guardar el offset inicial

    void Start()
    {
        // Configura la posición inicial de la cámara directamente detrás del jugador
        if (player != null)
        {
            transform.position = player.position + offset;
            transform.LookAt(player);
            initialOffset = offset; // Guarda el offset inicial
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcula la posición deseada
            Vector3 desiredPosition = player.position + offset;

            // Suaviza el movimiento de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Aplica la posición suavizada
            transform.position = smoothedPosition;

            // Ajusta la rotación para que mire al jugador
            transform.LookAt(player);

            // Limita el ángulo de rotación de la cámara
            LimitCameraRotation();
        }
    }

    private void LimitCameraRotation()
    {
        // Obtén el ángulo actual entre la cámara y el jugador
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float angle = Vector3.SignedAngle(transform.forward, directionToPlayer, Vector3.up);

        // Restringe el ángulo de rotación dentro del rango permitido
        if (Mathf.Abs(angle) > maxRotationAngle)
        {
            float clampedAngle = Mathf.Clamp(angle, -maxRotationAngle, maxRotationAngle);
            Quaternion targetRotation = Quaternion.Euler(0, clampedAngle, 0);
            transform.rotation = Quaternion.LookRotation(targetRotation * Vector3.forward, Vector3.up);
        }
    }
}
