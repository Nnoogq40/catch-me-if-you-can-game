using UnityEngine;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    public GameObject panelOpciones;
    public Slider sliderVolumen;

    private void Start()
    {
        // Cargar el volumen guardado
        sliderVolumen.value = PlayerPrefs.GetFloat("volumen", 1f);
        AudioListener.volume = sliderVolumen.value;
    }

    public void AbrirOpciones()
    {
        panelOpciones.SetActive(true);
    }

    public void CerrarOpciones()
    {
        panelOpciones.SetActive(false);
    }

    public void CambiarVolumen(float volumen)
    {
        AudioListener.volume = volumen;
        PlayerPrefs.SetFloat("volumen", volumen); // Guardar el volumen
        PlayerPrefs.Save();
    }
}
