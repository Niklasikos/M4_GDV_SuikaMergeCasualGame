using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsEffect : MonoBehaviour
{
    [SerializeField] private float flySpeed = 1;
    [SerializeField] private float length = 1;
    private Color color = Color.white;
    private float timer;
    private TextMeshPro text;
    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }

    public void TextUpdate(float points)
    {
        text.text = "+" + points;
    }
    void Update()
    {
        transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
        timer += Time.deltaTime;
        float alpha = Mathf.Lerp(color.a, 0f, timer / length);
        text.color = new Color(color.r, color.g, color.b, alpha);
        if(timer > length)
        {
            Destroy(gameObject);
        }
    }
}
