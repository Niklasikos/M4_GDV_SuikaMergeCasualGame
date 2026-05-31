using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    [SerializeField] private InputActionAsset input;
    [SerializeField] private float speed = 5f;
    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private TextMeshProUGUI multipliertext;
    [SerializeField] private GameObject WinUi;
    [SerializeField] private GameObject ballSize1;
    [SerializeField] private GameObject ballSize2;
    [SerializeField] private GameObject ballSize3;
    [SerializeField] private Sprite ballsize1Sprite;
    [SerializeField] private Sprite ballsize2Sprite;
    [SerializeField] private Sprite ballsize3Sprite;
    [SerializeField] private Image multiplierCircle;
    [SerializeField] private float multiplierTimer;
    [SerializeField] private float multiplierTimerStandart;
    [SerializeField] public float multiplier = 1;
    [SerializeField] private TextMeshProUGUI multiplierTimertext;
    [SerializeField] private TextMeshProUGUI finalScore;
    private float dropTimer;
    private SpriteRenderer sr;
    public bool gameOver = false;
    private InputAction moveAction;
    private InputAction dropAction;
    private InputAction restartAction;
    private InputAction quit;
    private Vector2 pos;
    private float score;
    private GameObject gameObjectChosen;
    Unity.Mathematics.Random rand;

    void Awake()
    {
        Time.timeScale = 1f;
        rand = new Unity.Mathematics.Random(1);
        InputActionMap map = input.FindActionMap("Player");
        moveAction = map.FindAction("Move");
        dropAction = map.FindAction("Drop");
        restartAction = map.FindAction("Restart");
        quit = map.FindAction("Quit");
        sr = GetComponent<SpriteRenderer>();
        dropTimer = 0f;
        score = 0;
        Instance = this;
    }
    void OnEnable()
    {
        moveAction.Enable();
    }
    void Start()
    {
        pos = transform.position;
        sr.sprite = ballsize1Sprite;
        scoretext.text = $"Score: {score}";
        multiplierTimer = 0f;
        gameObjectChosen = ballSize1;
        transform.localScale = ballSize1.transform.localScale;
        sr.sprite = ballsize1Sprite;
    }
    void RandomBall()
    {
        int random = rand.NextInt(1, 4);
        switch (random)
        {
            case 1:
                gameObjectChosen = ballSize1;
                transform.localScale = ballSize1.transform.localScale;
                sr.sprite = ballsize1Sprite;
                break;

            case 2:
                gameObjectChosen = ballSize2;
                transform.localScale = ballSize2.transform.localScale;
                sr.sprite = ballsize2Sprite;
                break;

            case 3:
                gameObjectChosen = ballSize3;
                transform.localScale = ballSize3.transform.localScale;
                sr.sprite = ballsize3Sprite;
                break;
        }
    }

    void Update()
    {
        multiplierTimer = Math.Clamp(multiplierTimer, 0f, multiplierTimerStandart);
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        // x -4/4
        pos.x += moveInput.x * speed * Time.deltaTime;
        pos.x = Math.Clamp(pos.x, -4, 4);

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);

        dropTimer += Time.deltaTime;
        multiplierTimer -= Time.deltaTime;
        multiplierCircle.fillAmount = multiplierTimer / multiplierTimerStandart;

        if (dropAction.WasPressedThisFrame() && dropTimer > 1f && gameOver == false)
        {
            // sr.sprite = null;
            GameObject drop = Instantiate(gameObjectChosen, new Vector3(pos.x, pos.y, -1), quaternion.identity);
            dropTimer = 0f;
            RandomBall();
        }
        if (restartAction.WasPressedThisFrame() && gameOver == true)
        {
            SceneManager.LoadScene("MainGame");
        }
        if (multiplierTimer <= 0)
        {
            multiplier = 1f;
            multipliertext.text = $"Multiplier: {multiplier}x";
        }
        multiplierTimertext.text = $"{Math.Ceiling(multiplierTimer)}";

        if(quit.WasPressedThisFrame())
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void UpdateScore(float punten)
    {
        score += punten * multiplier;
        scoretext.text = $"Score: {score}";
    }

    public void Won()
    {
        gameOver = true;
        Time.timeScale = 0;
        WinUi.SetActive(true);
        finalScore.text = $"Final Score: " + score;
    }

    public void Multiplier()
    {
        multiplierTimer = multiplierTimerStandart;
        multiplier++;
        multipliertext.text = $"Multiplier: {multiplier}x";
    }

}
