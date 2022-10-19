using UnityEngine;
using TMPro;

/// <summary>
/// 1. Floats the text upwards.
/// 2. Fades the text.
/// 3. Destroys the text.
/// </summary>

public class FloatingText : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private TextMeshProUGUI _text;

    private float _timer;
    private Color _startColor;

    void Start()
    {
        _startColor = _text.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, _moveSpeed * Time.deltaTime, 0);

        _timer += Time.deltaTime;
        _text.color = Color.Lerp(_startColor, Color.clear, _timer);

        if (_text.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
