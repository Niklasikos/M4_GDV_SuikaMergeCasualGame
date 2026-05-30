using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance {get; private set;}
    [SerializeField] private InputActionAsset input;
    [SerializeField] private float speed = 5f;
    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private TextMeshProUGUI multipliertext;
    [SerializeField] private GameObject WinUi;
    [SerializeField] private GameObject ballSize1;
    [SerializeField] private GameObject ballSize2;
    [SerializeField] private GameObject ballSize3;
    [SerializeField] private GameObject ballSize4;
    [SerializeField] private GameObject ballSize5;
    [SerializeField] private GameObject ballSize6;
    [SerializeField] private GameObject ballSize7;
    [SerializeField] private Sprite ballsize1Sprite;
    [SerializeField] private Sprite ballsize2Sprite;
    [SerializeField] private Sprite ballsize3Sprite;
    private float dropTimer;
    private SpriteRenderer sr;
    public bool gameOver = false;
    private InputAction moveAction;
    private InputAction dropAction;
    private InputAction restartAction;
    private Vector2 pos;
    private float score;

    void Awake()
    {
        Time.timeScale = 1f;
        InputActionMap map = input.FindActionMap("Player");
        moveAction = map.FindAction("Move");
        dropAction = map.FindAction("Drop");
        restartAction = map.FindAction("Restart");
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
    }

    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        // x -4/4
        pos.x += moveInput.x * speed * Time.deltaTime;
        pos.x = Math.Clamp(pos.x, -4, 4);

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);

        dropTimer += Time.deltaTime;

        if(dropAction.WasPressedThisFrame() && dropTimer > 0.5f && gameOver == false)
        {
            sr.sprite = null;
            GameObject drop = Instantiate(ballSize1, new Vector3(pos.x, pos.y, 0), quaternion.identity);
            dropTimer = 0f;
        }
        if(restartAction.WasPressedThisFrame() && gameOver == true)
        {
            SceneManager.LoadScene("MainGame");
        }
    }

    public void UpdateScore(float punten)
    {
        score+=punten;
        scoretext.text = $"Score: {score}";
    }

    public void Won()
    {
        gameOver = true;
        Time.timeScale = 0;
        WinUi.SetActive(true);
    }
}
