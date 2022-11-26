using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    readonly float deathTimer = 0.4f;

    public AudioSource death;

    public Animator anim;
    public string deathAnimName;

    public CharacterMovement character;
    public Rigidbody2D rb;

    bool shouldDie;
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Meteor" && !shouldDie) {
            shouldDie = true;
            Death();
        }
    }

    void Death()
    {
        death.Play();
        ManagerGame.Alive--;
        rb.velocity = new Vector3 (0,0,0);
        character.CanMove = false;
        anim.Play(deathAnimName);
        Destroy(gameObject, deathTimer);
        
        
    }
}
