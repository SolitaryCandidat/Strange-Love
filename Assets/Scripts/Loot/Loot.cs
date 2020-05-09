using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private Animator AnimOfLoot;
    void Start()
    {
        AnimOfLoot = GetComponent<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AnimOfLoot.SetBool("Destroy", true);
        }
    }
    public void LootDestroy()
    {
        Destroy(gameObject);
    }
}
