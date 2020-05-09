using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private float RobotSpeed;

    public AudioSource BlowSound;

    private BoxCollider2D ColliderOfRobot;
    private Animator AnimOfRobot;
    private void Start()
    {
        ColliderOfRobot = GetComponent<BoxCollider2D>();
        AnimOfRobot = GetComponent<Animator>();
    }
    void Update()
    {
        if(transform.position.x < 25)
        {
            transform.Translate(Vector2.left * RobotSpeed * Time.deltaTime);
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
            BlowSound.Play();
            ColliderOfRobot.enabled = false;
            gameObject.tag = "Enable";
            AnimOfRobot.SetBool("Blow", true);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            gameObject.tag = "Enable";
            AnimOfRobot.SetBool("Blow", true);
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
