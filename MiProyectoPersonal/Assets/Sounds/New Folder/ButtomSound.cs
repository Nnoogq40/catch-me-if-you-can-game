using UnityEngine;
using UnityEngine.UI;

public class ButtomSound : MonoBehaviour
{
    public AudioSource audioSource; // Referencia al AudioSource
    public AudioClip sonidoBoton;  // Sonido que se reproducir�

    void Start()
    {
        // Obtiene el componente AudioSource si no est� asignado
        if (audioSource == null)
        {
            audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();
        }

        // Obtiene el componente Button y le agrega el evento
        GetComponent<Button>().onClick.AddListener(ReproducirSonido);
    }

    void ReproducirSonido()
    {
        audioSource.PlayOneShot(sonidoBoton);
    }
}
