using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private float _startPosition, _length;
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _parallaxEffect;

    private void Start()
    {
        _startPosition = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float distance = _camera.transform.position.x * _parallaxEffect;
        float movement = _camera.transform.position.x * (1 - _parallaxEffect);

        transform.position = new Vector2(_startPosition + distance, transform.position.y);

        if (movement > _startPosition + _length) _startPosition += _length;
        else if (movement < _startPosition - _length) _startPosition -= _length;
    }
}
