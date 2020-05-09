using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject PlayerTransform;
    private Transform TransformOfPlayer;
    void Start()
    {
        TransformOfPlayer = PlayerTransform.GetComponent<Transform>();
    }
    void Update()
    {

        if((TransformOfPlayer.position.y >= -0.98f) && (StaticParams.PlayerLose == false))
        {
            transform.position = Vector2.Lerp(new Vector2(-13.9f, transform.position.y), new Vector2(-13.9f, TransformOfPlayer.position.y), 0.05f);
        }
        if ((TransformOfPlayer.position.y < -0.98f) && (StaticParams.PlayerLose == false))
        {
            transform.position = Vector2.Lerp(new Vector2(-13.9f, transform.position.y), new Vector2(-13.9f, -3.9f), 0.05f);
        }
        if (StaticParams.PlayerLose == true)
        {
            transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(-13.9f, -3.9f), 0.05f);
        }
    }
}
