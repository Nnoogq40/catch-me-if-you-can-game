using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public float velocidad = 2.0f;
    public GameObject target;

    public float raycastDistance = 1f; // Distancia para el raycast
    public float giroVelocidad = 0.5f; // Velocidad de rotación
    public LayerMask obstaculosLayer; // Capa de obstáculos para el Raycast

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;

            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, giroVelocidad);

                    // Verifica si hay una pared adelante con un Raycast
                    if (!Physics.Raycast(transform.position, transform.forward, raycastDistance, obstaculosLayer))
                    {
                        transform.position += transform.forward * velocidad * Time.deltaTime;
                        ani.SetBool("walk", true);
                    }
                    else
                    {
                        // Si detecta una pared, buscar una nueva dirección
                        BuscarNuevaDireccion();
                    }
                    break;
            }
        }
        else
        {
            var lookpos = target.transform.position - transform.position;
            lookpos.y = 0;
            var rotation = Quaternion.LookRotation(lookpos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            ani.SetBool("walk", false);
            ani.SetBool("run", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
    }

    // Método para buscar una nueva dirección cuando hay una pared
    void BuscarNuevaDireccion()
    {
        // Verifica si hay obstáculos a la derecha, izquierda o atrás
        if (!Physics.Raycast(transform.position, transform.right, raycastDistance, obstaculosLayer))
        {
            angulo = Quaternion.Euler(0, grado + 90, 0); // Gira a la derecha
        }
        else if (!Physics.Raycast(transform.position, -transform.right, raycastDistance, obstaculosLayer))
        {
            angulo = Quaternion.Euler(0, grado - 90, 0); // Gira a la izquierda
        }
        else
        {
            angulo = Quaternion.Euler(0, grado + 180, 0); // Gira 180 grados si no hay espacio
        }
        rutina = 1; // Cambia de rutina para seguir con el movimiento
    }

    void Update()
    {
        Comportamiento_Enemigo();
    }
}
