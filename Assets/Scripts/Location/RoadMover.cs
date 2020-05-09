using UnityEngine;
using UnityEditor;

public class RoadMover : MonoBehaviour
{
    [SerializeField] private GameObject[] Roads;
    [SerializeField] private float RoadSpeed;
    void Start()
    {
    }
    void Update()
    {
        if (StaticParams.GameActive)
        {
            transform.Translate(Vector2.left * RoadSpeed * StaticParams.GameSpeed * Time.deltaTime);
            if (transform.position.x <= -82.6f)
            {
                Instantiate(Roads[Random.Range(1, Roads.Length)], new Vector3(77.5f, 0, 0), Quaternion.Euler(0, 0, 0));
                Destroy(gameObject);
            }
        }
    }
}
