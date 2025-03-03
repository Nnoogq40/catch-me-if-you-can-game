using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public float speed;
    public float angle;
    public Vector3 direction;

    public bool puedeAbrir;
    public bool abrir;

    void Start()
    {
        angle = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.eulerAngles.y - angle) > 1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime * speed);
        }
        else
        {
            direction = Vector3.zero; // Detener rotación
        }

        if (Input.GetButtonDown("Fire1") && puedeAbrir)
        {
            if (!abrir)
            {
                angle = 90;
            }
            else
            {
                angle = 0;
            }
            abrir = !abrir; // Alterna entre abrir/cerrar
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            puedeAbrir = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            puedeAbrir = false;
        }
    }
}