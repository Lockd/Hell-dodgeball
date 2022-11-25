using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    float deathTimer = 0.4f;

    public Animator anim;
    public string deathAnimName;

    public CharacterMovement character;
    public Rigidbody2D rb;
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Meteor") {
            Death();
        }
    }
    void Death()
    {
        if (deathTimer > 0)
        {
            rb.velocity = new Vector3 (0,0,0);
            character.CanMove = false;
            anim.Play(deathAnimName);
            Destroy(gameObject, deathTimer);
            ManagerGame.Alive--;
        }
    }
}
