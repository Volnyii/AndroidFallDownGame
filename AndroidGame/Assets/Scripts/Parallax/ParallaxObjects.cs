using System;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxObjects : MonoBehaviour
{
    [SerializeField] private float _parallaxYSpeed;

    private Transform _transformParallaxObject;

    private void Awake()
    {
        _transformParallaxObject = GetComponent<Transform>();
    }

    private void Update()
    {
        _transformParallaxObject.position = new Vector3(_transformParallaxObject.position.x, _transformParallaxObject.position.y + (_parallaxYSpeed * 0.01f));
    }
}
