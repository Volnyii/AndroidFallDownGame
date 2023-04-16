using UnityEngine;


public class NoRotation: MonoBehaviour
{
    private Quaternion _startRotation;

    private void Awake()
    {
        _startRotation = transform.rotation;
    }

    private void Update()
    {
        transform.rotation = _startRotation;
    }
        
}
