using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Variables de movimiento
    public float runSpeed = 7;
    public float rotationSpeed = 250;
    public Animator animator;

    // Variables para pisadas
    public AudioSource footstepAudioSource;  // AudioSource para las pisadas
    public AudioClip[] footstepSounds;       // Array de sonidos de pisadas
    public float stepInterval = 0.5f;        // Intervalo entre las pisadas
    private float stepTimer = 0f;            // Temporizador para controlar el intervalo de las pisadas

    private float x, y;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Asegurarnos de que el AudioSource está asignado si no lo hemos hecho en el Inspector
        if (footstepAudioSource == null)
        {
            footstepAudioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Recoger la entrada del jugador
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Rotación y movimiento del personaje
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);

        // Establecer las variables de velocidad en el Animator
        animator.SetFloat("Velx", x);
        animator.SetFloat("Vely", y);

        // Si el personaje se está moviendo, manejamos el sonido de las pisadas
        if (x != 0 || y != 0)
        {
            stepTimer += Time.deltaTime;

            // Si ha pasado el intervalo de tiempo, reproducir el sonido de la pisada
            if (stepTimer >= stepInterval)
            {
                PlayFootstepSound();
                stepTimer = 0f;  // Resetear el temporizador
            }
        }
    }

    // Reproduce un sonido de pisada aleatorio
    void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            int index = Random.Range(0, footstepSounds.Length);
            footstepAudioSource.PlayOneShot(footstepSounds[index]);
        }
    }
}
