using Unity.Mathematics;
using UnityEngine;

public class Ball10 : MonoBehaviour
{
    [SerializeField] private GameObject pointsEffect;
    [SerializeField] private float punten = 5000f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball10"))
        {
            if (GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                return;
            }
            Vector3 pos = (transform.position + collision.gameObject.transform.position) / 2;
            GameObject points = Instantiate(pointsEffect, new Vector3(pos.x, pos.y, pos.z), quaternion.identity);
            points.GetComponent<PointsEffect>().TextUpdate(punten * PlayerController.Instance.multiplier);
            PlayerController.Instance.UpdateScore(punten);
            PlayerController.Instance.Won();
        }
    }
}
