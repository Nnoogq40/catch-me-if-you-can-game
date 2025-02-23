using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento del enemigo
    public float rotationSpeed = 5f;  // Velocidad de rotación del enemigo
    public Animator animator;  // Referencia al Animator para las animaciones
    public Transform player;  // Referencia al jugador
    private bool isChasing = false;  // Controla si el enemigo debe perseguir al jugador

    // Update is called once per frame
    void Update()
    {
        if (isChasing)  // Si el enemigo debe perseguir al jugador
        {
            MoveTowardsPlayer();
            UpdateAnimation();
        }
    }

    // Método para mover al enemigo hacia el jugador
    private void MoveTowardsPlayer()
    {
        // Calcular la dirección hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;

        // Rotar hacia el jugador
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // Mover hacia el jugador
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Actualiza las animaciones del enemigo (similar a las del jugador)
    private void UpdateAnimation()
    {
        // Comprobar si el enemigo está moviéndose
        float moveSpeed = Mathf.Abs(speed);

        // Pasamos el valor de velocidad a las animaciones
        if (moveSpeed > 0)
        {
            animator.SetFloat("Velx", 1f);  // Animación de movimiento en X (horizontal)
            animator.SetFloat("Vely", 1f);  // Animación de movimiento en Y (vertical)
        }
        else
        {
            animator.SetFloat("Velx", 0f);  // Detener animación si no se mueve
            animator.SetFloat("Vely", 0f);
        }
    }

    // Método para hacer que el enemigo comience a perseguir al jugador
    public void StartChasing()
    {
        isChasing = true;
    }
}
