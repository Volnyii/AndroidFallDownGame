using System;
using UnityEngine;
using Object = UnityEngine.Object;

public enum ObjectType
{
    Chicken,
    Cloud,
    Airplane
}

    public class CollisionObject: MonoBehaviour
    {
        [SerializeField] private ObjectType _objectType;
        private bool _isTriggered;
        private Counter _counterUI;

        private void Awake()
        {
            _counterUI = FindObjectOfType<Counter>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Player>() && !_isTriggered)
            {
                _counterUI.SetCounterValue(_objectType);
                _isTriggered = true;
            }
        }
    }
