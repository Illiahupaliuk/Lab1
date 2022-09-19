using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    public float MovementSpeed = 5.0f;
    public float JumpHeight = 5.0f;

    CapsuleCollider2D capsuleCollider;
    Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        //RigidBody
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movementVector = new Vector2(horizontalInput * MovementSpeed * 100 * Time.deltaTime, rbody.velocity.y);
        Debug.Log(Time.deltaTime);
        rbody.velocity = movementVector;
    }

    // Update is called once per frame
    void Update()
    {
        //Transform
        //Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //transform.Translate(movementVector * MovementSpeed * Time.deltaTime);

     
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVector = new Vector2(0f, JumpHeight);
            rbody.velocity += jumpVector;
            //rbody.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
        }
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) ;
        {
            return;
        }
    }
}
