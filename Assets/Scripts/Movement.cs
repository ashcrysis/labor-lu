using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpingPower;
    [SerializeField] private float playerSpeed;
    private float horizontal;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        float targetVelocityX = horizontal * playerSpeed;
        float smoothVelocityX = Mathf.Lerp(rb.velocity.x, targetVelocityX, Time.deltaTime * 2);

        rb.AddForce(new Vector2(smoothVelocityX - rb.velocity.x, 0), ForceMode2D.Impulse);
       
         if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
        }
    }
private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.001f, groundLayer);
    }

    public float isFacingRight()
    {
        return horizontal;
    }
}
