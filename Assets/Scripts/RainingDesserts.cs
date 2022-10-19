using UnityEngine;
using UnityEngine.UI;

public class RainingDesserts : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private Texture2D[] _images;

    private RawImage _img;
    private float _timer;

    private void Start()
    {
        int rdmnmb = Random.Range(0, _images.Length);
        _img = GetComponent<RawImage>();
        _img.texture = _images[rdmnmb];
    }

    void Update()
    {
        transform.Translate(0, _moveSpeed * Time.deltaTime, 0);

        _timer += Time.deltaTime;

        if (_timer > 6)
        {
            Destroy(gameObject);
        }
    }
}
