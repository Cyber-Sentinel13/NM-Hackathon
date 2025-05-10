using UnityEngine;

public class TapColorChanger : MonoBehaviour
{
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        ChangeColor();
    }

    void ChangeColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        objectRenderer.material.color = randomColor;
    }
}
