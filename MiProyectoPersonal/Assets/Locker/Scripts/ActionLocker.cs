using UnityEngine;

public class ActionLocker : MonoBehaviour
{
    public Transform casillero;  // Referencia al casillero
    public KeyCode teclaInteraccion = KeyCode.E;  // Tecla para entrar al casillero
    private bool dentroDelCasillero = false;  // Para saber si el jugador está dentro
    private bool cercaDelCasillero = false;  // Para detectar la cercanía al casillero

    private void Update()
    {
        // Detecta si el jugador está cerca del casillero y presiona la tecla "E"
        if (cercaDelCasillero && Input.GetKeyDown(teclaInteraccion))
        {
            if (!dentroDelCasillero)
            {
                EntrarEnCasillero(); // Llama al método para entrar en el casillero
            }
            else
            {
                SalirDelCasillero(); // Llama al método para salir del casillero
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador (con el tag "Player") está cerca del casillero
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador cerca del casillero.");
            cercaDelCasillero = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el jugador ha salido del área del casillero
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador salió del área del casillero.");
            cercaDelCasillero = false;
        }
    }

    private void EntrarEnCasillero()
    {
        // Mueve al personaje a la posición del casillero (ajustamos un poco para que quede dentro)
        transform.position = casillero.position + new Vector3(0, 1, 0);  // Ajusta la posición a tus necesidades
        dentroDelCasillero = true;
        Debug.Log("Jugador entró al casillero.");
    }

    private void SalirDelCasillero()
    {
        // Mueve al personaje fuera del casillero (ajusta esta posición según tus necesidades)
        transform.position = new Vector3(0, 1, 0);  // Ajusta esta posición para que salga correctamente
        dentroDelCasillero = false;
        Debug.Log("Jugador salió del casillero.");
    }
}
