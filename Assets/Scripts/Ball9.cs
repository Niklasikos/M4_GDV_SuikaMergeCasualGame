using Unity.Mathematics;
using UnityEngine;

public class Ball9 : MonoBehaviour
{
    [SerializeField] private GameObject ballSize10;
    [SerializeField] private GameObject pointsEffect;
    [SerializeField] private float punten = 225f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball9"))
        {
            if (GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                return;
            }
            Vector3 pos = (transform.position + collision.gameObject.transform.position) / 2;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameObject Ball10 = Instantiate(ballSize10, new Vector3(pos.x, pos.y, pos.z), quaternion.identity);
            GameObject points = Instantiate(pointsEffect, new Vector3(pos.x, pos.y, pos.z), quaternion.identity);
            points.GetComponent<PointsEffect>().TextUpdate(punten);
            PlayerController.Instance.UpdateScore(punten);
        }
    }
}
