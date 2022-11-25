using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10f;
    public float maxSpeed = 20f;
    public Rigidbody2D rb;

    void Update()
    {
        float horizontalDirection = Input.GetAxisRaw("Horizontal") * speed;
        float verticalDirection = Input.GetAxisRaw("Vertical") * speed;

        rb.velocity = new Vector2 (horizontalDirection, verticalDirection);
    }
}
