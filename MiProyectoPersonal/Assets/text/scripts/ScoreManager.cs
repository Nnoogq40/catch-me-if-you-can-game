using UnityEngine;
using UnityEngine.UI;  // Necesario para trabajar con UI

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;  // Referencia al Text UI donde mostraremos el puntaje
    private int score = 0;  // Puntaje del jugador

    // Este método se llamará para agregar puntos
    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();  // Actualizar el texto del puntaje
    }

    // Actualizar el texto en pantalla con el puntaje actual
    void UpdateScoreText()
    {
        scoreText.text = "Puntos: " + score;  // Actualiza el texto para mostrar el puntaje
    }
}
