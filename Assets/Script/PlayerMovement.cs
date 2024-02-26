using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

   private Rigidbody rb;
   [SerializeField] private float forward_Speed = 0;
   [SerializeField] private float Direction_Speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(-forward_Speed * Time.deltaTime,rb.velocity.y,rb.velocity.z);

        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Input.GetAxis("Horizontal") * Direction_Speed * Time.deltaTime);
        }
    }


}
