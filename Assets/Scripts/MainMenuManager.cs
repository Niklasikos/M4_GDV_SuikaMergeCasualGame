using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset input;
    [SerializeField] private Button start;
    [SerializeField] private Button quit;
    private InputAction dropAction;
    private InputAction restartAction;
    private InputAction quitGame;
    void Start()
    {
        InputActionMap map = input.FindActionMap("Player");
        dropAction = map.FindAction("Drop");
        restartAction = map.FindAction("Restart");
        quitGame = map.FindAction("Quit");
    }

    void Update()
    {
        if(dropAction.WasPressedThisFrame())
        {
            start.onClick.Invoke();
        }
        if(restartAction.WasPressedThisFrame())
        {
            quit.onClick.Invoke();
        }
        if(quitGame.WasPressedThisFrame())
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
