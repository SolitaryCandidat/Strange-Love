using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOfLoseButtons : MonoBehaviour
{
    [SerializeField] private float ButtonsSpeed;
    void FixedUpdate()
    {
        if(transform.position.y < -10)
        {
            transform.Translate(Vector2.up * Time.deltaTime * ButtonsSpeed);
        }
    }
}
