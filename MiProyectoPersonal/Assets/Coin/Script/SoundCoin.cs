using UnityEngine;

public class SoundCoin : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip coinSound; // Sonido de la moneda

    void Start()
    {
        // Obtener o agregar un AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Si no hay, lo agregamos
        }

        audioSource.playOnAwake = false; // Evita que el sonido se reproduzca al inicio
        audioSource.enabled = true; // Asegura que el AudioSource esté activado
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Solo el jugador activa la moneda
        {
            if (coinSound != null && audioSource != null)
            {
                audioSource.enabled = true; // Habilitar por seguridad
                audioSource.PlayOneShot(coinSound); // Reproducir sonido
            }

            GetComponent<MeshRenderer>().enabled = false; // Ocultar moneda
            GetComponent<Collider>().enabled = false; // Evitar que se recoja varias veces

            Destroy(gameObject, coinSound.length); // Destruir después de que termine el sonido
        }
    }
}
    