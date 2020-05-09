using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuClouds : MonoBehaviour
{
    [SerializeField] private float CloudSpeed;
    public GameObject[] Clouds;
    void Update()
    {
        transform.Translate(Vector2.left * CloudSpeed * Time.deltaTime);
        if(transform.position.x < -20)
        {
            Instantiate(Clouds[Random.Range(0,1)], new Vector3(15, 3, 0), Quaternion.Euler(0, 0, 0));        
            Destroy(gameObject);
        }
    }
}
