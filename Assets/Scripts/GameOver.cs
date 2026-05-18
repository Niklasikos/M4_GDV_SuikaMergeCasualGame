using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController.Instance.gameOver = true;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
}
