using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.Mathematics;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionAsset input;
    [SerializeField] private float speed = 5f;
    [SerializeField] private TextMeshProUGUI scoretext;
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
    private SpriteRenderer sr;

    private InputAction moveAction;
    private InputAction dropAction;
    private InputAction restartAction;
    private Vector2 pos;
    private float score;

    void Awake()
    {
        InputActionMap map = input.FindActionMap("Player");
        moveAction = map.FindAction("Move");
        dropAction = map.FindAction("Drop");
        restartAction = map.FindAction("Restart");
        sr = GetComponent<SpriteRenderer>();
    }
    void OnEnable()
    {
        moveAction.Enable();
    }
    void Start()
    {
        pos = transform.position;
        sr.sprite = ballsize1Sprite;
    }

    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        // x -4/4
        pos.x += moveInput.x * speed * Time.deltaTime;
        pos.x = Math.Clamp(pos.x, -4, 4);

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);

        if(dropAction.WasPressedThisFrame())
        {
            sr.sprite = null;
            GameObject drop = Instantiate(ballSize1, new Vector3(pos.x, pos.y, 0), quaternion.identity);
        }
    }
}
