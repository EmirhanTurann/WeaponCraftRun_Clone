using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

   private Rigidbody rb;
    [SerializeField] private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(-speed*Time.deltaTime,rb.velocity.y,rb.velocity.z);
    }
}
