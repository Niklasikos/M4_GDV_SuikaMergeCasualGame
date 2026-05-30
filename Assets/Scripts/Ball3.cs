using Unity.Mathematics;
using UnityEngine;

public class Ball3 : MonoBehaviour
{
    [SerializeField] private GameObject ballSize4;
    [SerializeField] private GameObject pointsEffect;
    [SerializeField] private float punten = 100f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball3"))
        {
            if (GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                return;
            }
            Vector3 pos = (transform.position + collision.gameObject.transform.position) / 2;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameObject Ball4 = Instantiate(ballSize4, new Vector3(pos.x, pos.y, pos.z), quaternion.identity);
            GameObject points = Instantiate(pointsEffect, new Vector3(pos.x, pos.y, pos.z), quaternion.identity);
            points.GetComponent<PointsEffect>().TextUpdate(punten);
            PlayerController.Instance.UpdateScore(punten);
        }
    }
}
