using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    readonly float deathTimer = 0.4f;
    public AudioSource deathAudio;
    public Animator anim;
    public string deathAnimName;
    public CharacterMovement character;
    public Rigidbody2D rb;
    CharacterInitializator characterInitializator;
    bool shouldDie;
    [HideInInspector] public float enableColliderAfter;
    [HideInInspector] public bool isVulnerable = true;
    [SerializeField] private AudioSource collectingSound;
    
    void Start()
    {
        characterInitializator = FindObjectOfType<CharacterInitializator>();
    }

    void Update()
    {
        if (!isVulnerable && Time.time > enableColliderAfter)
        {
            isVulnerable = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Meteor" && !shouldDie && isVulnerable)
        {
            shouldDie = true;
            onDeath();
        }

        if (col.tag == "Collectable")
        {
            collectingSound.Play();
            onResurectDino(col);
        }
    }

    void onDeath()
    {
        deathAudio.Play();
        ManagerGame.reduceAmountOfAliveDinos();
        rb.velocity = new Vector3(0, 0, 0);
        character.CanMove = false;
        anim.Play(deathAnimName);
        Destroy(gameObject, deathTimer);
    }

    void onResurectDino(Collider2D col)
    {
        Destroy(col.gameObject);
        characterInitializator.spawnDino(true);
    }
}
