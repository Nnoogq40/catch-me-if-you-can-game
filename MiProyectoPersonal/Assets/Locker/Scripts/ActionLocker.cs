using UnityEngine;

public class LockerInteraction : MonoBehaviour
{
    public Transform insideLockerPosition; // Posición dentro del casillero
    public Transform outsideLockerPosition; // Posición fuera del casillero
    public Transform lockerViewPoint; // Punto de vista dentro del casillero
    private bool isInside = false;
    private bool nearLocker = false;
    private GameObject player;
    private Rigidbody playerRb;
    private MonoBehaviour playerMovementScript;
    private Camera playerCamera;
    private Transform originalCameraParent;
    private Vector3 originalCameraPosition;
    private Quaternion originalCameraRotation;
    private MonoBehaviour cameraFollowScript; // Guarda el script de seguimiento de la cámara

    void Start()
    {
        playerCamera = Camera.main; // Obtiene la cámara principal
        originalCameraParent = playerCamera.transform.parent; // Guarda el padre original de la cámara
        originalCameraPosition = playerCamera.transform.position;
        originalCameraRotation = playerCamera.transform.rotation; // Guarda la rotación original

        // Busca un script de seguimiento en la cámara (ajusta según el script que uses)
        cameraFollowScript = playerCamera.GetComponent<MonoBehaviour>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearLocker = true;
            player = other.gameObject;
            playerRb = player.GetComponent<Rigidbody>();
            playerMovementScript = player.GetComponent<MonoBehaviour>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearLocker = false;
        }
    }

    void Update()
    {
        if (nearLocker && Input.GetKeyDown(KeyCode.E))
        {
            if (!isInside) // Entrar al casillero
            {
                player.transform.position = insideLockerPosition.position;
                playerRb.linearVelocity = Vector3.zero;
                playerRb.isKinematic = true;
                if (playerMovementScript != null)
                    playerMovementScript.enabled = false;

                // Desactivar el script de seguimiento de la cámara si existe
                if (cameraFollowScript != null)
                    cameraFollowScript.enabled = false;

                // Mueve la cámara al punto de vista dentro del casillero
                if (lockerViewPoint != null)
                {
                    playerCamera.transform.SetParent(lockerViewPoint);
                    playerCamera.transform.position = lockerViewPoint.position;
                    playerCamera.transform.rotation = lockerViewPoint.rotation;
                }
                else
                {
                    Debug.LogError("lockerViewPoint no está asignado en el Inspector.");
                }
            }
            else // Salir del casillero
            {
                player.transform.position = outsideLockerPosition.position;
                playerRb.isKinematic = false;
                if (playerMovementScript != null)
                    playerMovementScript.enabled = true;

                // Restaurar la cámara a su posición y activar el seguimiento
                playerCamera.transform.SetParent(originalCameraParent);
                playerCamera.transform.position = originalCameraPosition;
                playerCamera.transform.rotation = originalCameraRotation;

                // Reactivar el script de seguimiento de la cámara
                if (cameraFollowScript != null)
                    cameraFollowScript.enabled = true;
            }

            isInside = !isInside;
        }
    }
}
