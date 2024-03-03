using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

   private Rigidbody rb;
   [SerializeField] private float Defaultforward_Speed = 0;
    [SerializeField] private float forward_Speed = 0;
    [SerializeField] private float Direction_Speed = 0;
   //[SerializeField] private GameObject PlayerCanvas;
   //[SerializeField] private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward_Speed = Defaultforward_Speed;
    }

   
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(-forward_Speed * Time.deltaTime,rb.velocity.y,rb.velocity.z);

        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Input.GetAxis("Horizontal") * Direction_Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Money"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("increaseSpeed"))
        {

            forward_Speed += forward_Speed/2;
        }
        if (other.CompareTag("decreaseSpeed"))
        {
            forward_Speed -=  forward_Speed / 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("increaseSpeed"))
        {
            forward_Speed = Defaultforward_Speed;
        }
        if (other.CompareTag("decreaseSpeed"))
        {

            forward_Speed = Defaultforward_Speed;
        }
    }
}
