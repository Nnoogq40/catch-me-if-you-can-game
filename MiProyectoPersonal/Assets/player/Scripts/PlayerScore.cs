using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;  // Puntuaci�n del jugador

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Puntos: " + score);  // Mostrar los puntos en la consola
    }
}
