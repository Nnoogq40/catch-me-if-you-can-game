using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float runSpeed =7;
    public float rotationSpeed = 250;
    public Animator animator;
    private float x, y;


    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime *rotationSpeed,0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);
        animator.SetFloat("Velx",x);
        animator.SetFloat("Vely",y);

    }
}
