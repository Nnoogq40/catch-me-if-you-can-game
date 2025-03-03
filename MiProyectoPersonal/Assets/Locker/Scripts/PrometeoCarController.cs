using UnityEngine;

public class PrometeoCarController : MonoBehaviour
{
    public bool useSounds = true;                // Controla si se deben reproducir los sonidos del coche
    public AudioSource carEngineSound;           // Sonido del motor
    public AudioSource tireScreechSound;         // Sonido de los neumáticos al frenar

    // No necesitamos Rigidbody o cualquier cosa relacionada con el movimiento
    // private Rigidbody rb;

    void Start()
    {
        // Si tienes un Rigidbody o alguna otra configuración inicial, puedes agregarla aquí.
        // rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        // Aquí verificamos si el coche tiene que emitir sonido, pero no moveremos nada.
        if (useSounds)
        {
            // El sonido del motor solo se reproduce si el coche tiene alguna velocidad.
            // Pero como el coche no se moverá, no se reproducirá el sonido del motor.
            if (!carEngineSound.isPlaying)
            {
                carEngineSound.Stop(); // Aseguramos que el motor no esté sonando si no se mueve.
            }
        }
    }

    // Método para frenar el coche (aunque no se mueve, mantendremos esta función)
    public void Brakes()
    {
        // Como el coche no se moverá, no necesitamos afectar la física ni la velocidad.
        if (useSounds)
        {
            tireScreechSound.Play();            // Reproduce el sonido de los frenos
        }
    }
}
