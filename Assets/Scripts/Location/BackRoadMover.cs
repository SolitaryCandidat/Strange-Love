using UnityEditor;
using UnityEngine;

public class BackRoadMover : MonoBehaviour
{
    [SerializeField] private GameObject BackRoad;
    [SerializeField] private float BackRoadSpeed;
    void Update()
    {
        if (StaticParams.GameActive)
        {
            transform.Translate(Vector2.left * BackRoadSpeed * StaticParams.GameSpeed * Time.deltaTime);
            if (transform.position.x <= -79)
            {
                Instantiate(BackRoad, new Vector3(60.9f, -8.6f, 0), Quaternion.Euler(0, 0, 0));
                Destroy(gameObject);
            }
        }
    }
}
