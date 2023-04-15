using UnityEngine;

    public class CollisionObject: MonoBehaviour
    {
        [SerializeField] private bool _chiken;
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
                _counterUI.SetCounterValue(_chiken);
                _isTriggered = true;
            }
        }
        
    }
