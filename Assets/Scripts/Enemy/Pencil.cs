using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : MonoBehaviour
{
    [SerializeField] private float PencilSpeed;
    [SerializeField] private Vector2 Direction;
    private BoxCollider2D ColliderOfPencil;
    public AudioSource Blow;

    private Animator AnimOfPencil;
    void Start()
    {
        ColliderOfPencil = GetComponent<BoxCollider2D>();
        AnimOfPencil = GetComponent<Animator>();
    }
    void Update()
    {
        if (transform.position.x < 25)
        {
            transform.Translate(Direction * PencilSpeed * Time.deltaTime);
        }
        if(transform.position.y < -22)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -50)
        {
            Destroy(gameObject);
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("DarkSideOfTheMoon"))
        {
            Blow.Play();
            AnimOfPencil.SetBool("Destroy", true);
            ColliderOfPencil.enabled = false;
            gameObject.tag = "Enable";
            Direction = new Vector2(-1, -1);
        }
    }
}