using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Material _material;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            _material = renderer.material;
        }
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (_material != null)
            {
                Color randomColor = Random.ColorHSV();

                Color rgbColor = Color.HSVToRGB(randomColor.r, randomColor.g, randomColor.b);

                _material.color = rgbColor;
            }
        }
    }
}
