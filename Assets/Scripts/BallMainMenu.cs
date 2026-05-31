using UnityEngine;
using Unity.Mathematics;
using System;

public class BallMainMenu : MonoBehaviour
{
    Vector2 pos;
    [SerializeField] private float speed = 2f;
    private int direction = 1;

    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos.x += direction * speed * Time.deltaTime;

        if (pos.x >= 0f)
        {
            pos.x = 0f;
            direction = -1;
        }
        else if (pos.x <= -8f)
        {
            pos.x = -8f;
            direction = 1;
        }

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
