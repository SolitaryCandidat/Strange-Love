using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPinkFloyd : MonoBehaviour
{
    [SerializeField] private float AttackSpeed;
    void Update()
    {
        transform.Translate(Vector2.right * AttackSpeed * Time.deltaTime);
        if(transform.position.x > 12.5)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Robot"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Pencil"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Bird"))
        {
            Destroy(gameObject);
        }
    }
}
