using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación de la moneda
    public int pointsPerCoin = 1; // Puntos que da la moneda al ser recolectada
    public EnemyAI enemyAI; // Referencia al EnemyAI del enemigo
    public AudioClip coinSound; // Sonido de la moneda

    private AudioSource audioSource;
    private bool collected = false; // Para evitar múltiples activaciones

    private void Start()
    {
        // Obtener o agregar un AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        audioSource.enabled = true;
    }

    private void Update()
    {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!collected && other.CompareTag("Player"))
        {
            collected = true;

            // Sumar puntos
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddPoints(pointsPerCoin);
            }

            // Activar la persecución del enemigo
            if (enemyAI != null)
            {
                enemyAI.StartChasing();
            }

            // Reproducir sonido si está asignado
            float soundDuration = 0f;
            if (coinSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(coinSound);
                soundDuration = coinSound.length;
            }
            else
            {
                Debug.LogWarning("⚠️ No se ha asignado un sonido a la moneda.");
            }

            // Ocultar moneda visualmente
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            // Destruir después del sonido o inmediatamente si no hay sonido
            Destroy(gameObject, soundDuration);
        }
    }
}
