using Unity.Mathematics;
using UnityEngine;

public class Ball1 : MonoBehaviour
{
    [SerializeField] private GameObject ballSize2;
    [SerializeField] private float punten = 50f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball1"))
        {
            if (GetInstanceID() < collision.gameObject.GetInstanceID())
            {
                return;
            }
            Vector3 pos = (transform.position + collision.gameObject.transform.position) / 2;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameObject Ball2 = Instantiate(ballSize2, new Vector3(pos.x, pos.y, pos.z), quaternion.identity);
            PlayerController.Instance.UpdateScore(punten);
        }
    }
}
