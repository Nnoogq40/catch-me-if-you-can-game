using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;  // Puntuación del jugador

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Puntos: " + score);  // Mostrar los puntos en la consola
    }
}
