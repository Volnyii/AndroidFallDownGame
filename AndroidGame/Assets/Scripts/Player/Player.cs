using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private InputPanel _inputPanel;
    private Rigidbody2D _player;
    [SerializeField] private TriggerZone _triggerZone;
    [Inject] private GameController _gameController;
    [SerializeField] private float _horizontalSpeed;
   
    private Vector3 _inputVector;
    private bool _faceRight;
    
    private void Awake()
    {
        _inputPanel = FindObjectOfType<InputPanel>();
        _inputPanel.OnDragEvent += InputPanelOnOnDragEvent;
        _player = FindObjectOfType<Rigidbody2D>();
        _triggerZone.OnPlayerInside += TriggerZoneOnOnPlayerInside;
    }

    private void TriggerZoneOnOnPlayerInside(GameItem gameItem)
    {
        _gameController.Info.ScoreInfo.ChangeScore(gameItem.Value, gameItem.ObjectType);
    }

    private void FlipPlayer()
    {
        if (_inputVector.x < 0 && !_faceRight || _inputVector.x > 0 && _faceRight)
        {
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;

            _faceRight = !_faceRight;
        }
    }

    private void InputPanelOnOnDragEvent(float inputX)
    {
        var sign = Mathf.Sign(inputX);
        var resultSpeed = inputX == 0f ? 0f : _horizontalSpeed * sign;
        _player.velocity = new Vector2(resultSpeed * _horizontalSpeed, _player.velocity.y);
    }


    private void Update()
    {
        var x = Input.GetAxis("Horizontal");

        _inputVector.x = Input.GetAxisRaw("Horizontal");
        FlipPlayer();
    }
}
