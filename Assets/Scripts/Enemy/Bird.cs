using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Vector2 Direction;
    [SerializeField] private Vector2 Direction_2;
    [SerializeField] private float BirdSpeed;

    private BoxCollider2D ColliderOfBird;
    private Rigidbody2D RbOfBird;
    private Animator AnimOfBird;

    public AudioSource BlowSound;
    void Start()
    {
        ColliderOfBird = GetComponent<BoxCollider2D>();
        RbOfBird = GetComponent<Rigidbody2D>();
        AnimOfBird = GetComponent<Animator>();
    }
    void Update()
    {
        if (transform.position.x < 25)
        {
            transform.Translate(Direction * BirdSpeed * Time.deltaTime);
        }
        if (transform.position.x < 5)
        {
            BirdSpeed = 0;
            AnimOfBird.SetBool("RedyForAttack", true);
        }
        if (transform.position.y < -25)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -60)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("DarkSideOfTheMoon"))
        {
            Blow();
        }
    }
    public void AttackOfBird()
    {
        AnimOfBird.SetBool("RedyForAttack", false);
        RbOfBird.AddForce(Direction_2 * 20, ForceMode2D.Impulse);
    }
    public void Blow()
    {
        BlowSound.Play();
        ColliderOfBird.enabled = false;
        gameObject.tag = "Enable";
        AnimOfBird.SetBool("Blow", true);
    }
    public void DestroyBird()
    {
        Destroy(gameObject);
    }
}
