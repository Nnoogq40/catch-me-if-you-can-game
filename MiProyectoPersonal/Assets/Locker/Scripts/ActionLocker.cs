using UnityEngine;

public class ActionLocker : MonoBehaviour
{
    public Transform casillero;  // Referencia al casillero
    public KeyCode teclaInteraccion = KeyCode.E;  // Tecla para entrar al casillero
    private bool dentroDelCasillero = false;  // Para saber si el jugador est� dentro
    private bool cercaDelCasillero = false;  // Para detectar la cercan�a al casillero

    private void Update()
    {
        // Detecta si el jugador est� cerca del casillero y presiona la tecla "E"
        if (cercaDelCasillero && Input.GetKeyDown(teclaInteraccion))
        {
            if (!dentroDelCasillero)
            {
                EntrarEnCasillero(); // Llama al m�todo para entrar en el casillero
            }
            else
            {
                SalirDelCasillero(); // Llama al m�todo para salir del casillero
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador (con el tag "Player") est� cerca del casillero
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador cerca del casillero.");
            cercaDelCasillero = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el jugador ha salido del �rea del casillero
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador sali� del �rea del casillero.");
            cercaDelCasillero = false;
        }
    }

    private void EntrarEnCasillero()
    {
        // Mueve al personaje a la posici�n del casillero (ajustamos un poco para que quede dentro)
        transform.position = casillero.position + new Vector3(0, 1, 0);  // Ajusta la posici�n a tus necesidades
        dentroDelCasillero = true;
        Debug.Log("Jugador entr� al casillero.");
    }

    private void SalirDelCasillero()
    {
        // Mueve al personaje fuera del casillero (ajusta esta posici�n seg�n tus necesidades)
        transform.position = new Vector3(0, 1, 0);  // Ajusta esta posici�n para que salga correctamente
        dentroDelCasillero = false;
        Debug.Log("Jugador sali� del casillero.");
    }
}
