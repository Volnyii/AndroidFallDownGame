using System;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxObjects : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _parallaxYSpeed;
    [SerializeField] private float _parallaxfactor = 0.5f;
    [SerializeField] private float _index = 0.01f;

    private Transform _transformParallaxObject;
   // private InputPanel _inputPanel;

    private Vector3 _startPosition;
    private Vector3 _offsetFromPlayer => _playerBody.position - transform.position;

    private void Awake()
    {
     //   _inputPanel = FindObjectOfType<InputPanel>();
      //  _inputPanel.OnDragEvent += HorizontalMovement;
        _transformParallaxObject = GetComponent<Transform>();
        _startPosition = transform.position;
    }

    // private void HorizontalMovement(float speed)
    // {
    //     _transformParallaxObject.position = new Vector3(_transformParallaxObject.position.x + (speed * _index), _transformParallaxObject.position.y);
    // }

    private void Update()
    {
        var newV = _startPosition + _offsetFromPlayer * _parallaxfactor;
        _transformParallaxObject.position = new Vector3(newV.x, _transformParallaxObject.position.y + (_parallaxYSpeed * _index));
     //   _transformParallaxObject.position = new Vector3(_transformParallaxObject.position.x, _transformParallaxObject.position.y + (_parallaxYSpeed * _index));
    }
}
