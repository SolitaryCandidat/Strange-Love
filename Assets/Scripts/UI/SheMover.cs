using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheMover : MonoBehaviour
{
    private Rigidbody2D RbOfShe;
    void Start()
    {
        RbOfShe = GetComponent<Rigidbody2D>();
    }
    public void Down()
    {
        RbOfShe.bodyType = RigidbodyType2D.Dynamic;
    }
}
