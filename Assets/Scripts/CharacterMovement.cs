using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public float maxSpeed = 20f;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer rend;
    public ParticleSystem dustTrail;
     bool moving;

    bool canMove = true;

    void Update()
    {
        if (canMove)
        {
            float horizontalDirection = Input.GetAxisRaw("Horizontal");
            float verticalDirection = Input.GetAxisRaw("Vertical");

            if (new Vector2(horizontalDirection, verticalDirection).Equals(new Vector2(0, 0))) moving = false;
            else moving = true;


            if (moving && dustTrail != null && !dustTrail.isPlaying) dustTrail.Play();
            
            if (!moving && dustTrail != null) dustTrail.Stop();

            if (anim != null) anim.SetBool("moving", moving);
            if (horizontalDirection != 0)
                transform.localScale = new Vector3(horizontalDirection / Mathf.Abs(horizontalDirection), transform.localScale.y, transform.localScale.z);

            rb.velocity = new Vector2(horizontalDirection, verticalDirection).normalized * speed;
        }
    }

    public bool CanMove
    {
        set
        {
            canMove = value;
        }
    }

}
