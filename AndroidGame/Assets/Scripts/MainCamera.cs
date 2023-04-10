using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _minZoom;
    [SerializeField] private float _maxZoom;
    private Vector3 _offset;
    private Camera _camera;
    
    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _offset = transform.position - _player.transform.position;
        _camera = GetComponent<Camera>();
    }

    public void CameraZoom(bool zoomIn, float value)
    {
        _camera.orthographicSize = zoomIn ? Mathf.Lerp(_maxZoom, _minZoom, value) : 
            Mathf.Lerp(_minZoom, _maxZoom, value);
    }
    
    private void Update() 
    {        
        transform.position = _player.transform.position + _offset;
    }
}
