using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;         // El jugador al que se va a seguir
    public float mouseSensitivity = 100f;  // Sensibilidad del mouse
    public float clampAngle = 80f;   // �ngulo m�ximo de inclinaci�n vertical
    public Transform playerBody;     // Cuerpo del jugador (para rotarlo de lado)

    private float rotationX = 0f;    // Rotaci�n sobre el eje X (arriba y abajo)
    private float rotationY = 0f;    // Rotaci�n sobre el eje Y (izquierda y derecha)

    void Update()
    {
        // Obtener el movimiento del mouse en los ejes X y Y
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  // Movimiento horizontal
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;  // Movimiento vertical

        // Limitar el �ngulo vertical para evitar que se voltee
        rotationY = Mathf.Clamp(rotationY, -clampAngle, clampAngle);

        // Rotar el cuerpo del jugador solo en el eje Y (izquierda y derecha)
        playerBody.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime);

        // Aplicar la rotaci�n vertical a la c�mara (eje X)
        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
    }
}
