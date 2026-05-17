using UnityEngine;

public class Ball1 : MonoBehaviour
{
    void OCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball1"))
        {
            
        }
    }
}
