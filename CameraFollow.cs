using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _offset = new Vector3(0, 0, -10);
    private float _smoothTime = 0.25f;
    private Vector3 _velocity = Vector3.zero;

    [SerializeField] private Transform _target;

    private void FixedUpdate()
    {
        Vector3 targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }
}
