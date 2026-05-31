using Unity.Mathematics;
using UnityEngine;

public class Ball7 : MonoBehaviour
{
    [SerializeField] private GameObject ballSize8;
    [SerializeField] private GameObject pointsEffect;
    [SerializeField] private float punten = 175f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball7"))
        {
            if (GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                return;
            }
            Vector3 pos = (transform.position + collision.gameObject.transform.position) / 2;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameObject Ball8 = Instantiate(ballSize8, new Vector3(pos.x, pos.y, pos.z), quaternion.identity);
            GameObject points = Instantiate(pointsEffect, new Vector3(pos.x, pos.y, pos.z), quaternion.identity);
            points.GetComponent<PointsEffect>().TextUpdate(punten * PlayerController.Instance.multiplier);
            PlayerController.Instance.UpdateScore(punten);
            PlayerController.Instance.Multiplier();
        }
    }
}
