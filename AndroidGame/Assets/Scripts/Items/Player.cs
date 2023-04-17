using UnityEngine;

public class Player : MonoBehaviour
{
    private InputPanel _inputPanel;
    private Rigidbody2D _player;
    [SerializeField] private Transform _playerTuplePoint;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private int _speedForCamScale;
    [SerializeField] private int _speedForEffect;
    [SerializeField] private int _maxFallDownSpeed;
    private MainCamera _camera;
    private SpeedEffect _speedEffect;
    private bool _isCameraZoomed;
    private bool _isSpeedEffectTurnedOn;
    
    private Vector3 _inputVector;
    private bool _faceRight;

    public float yDiff { get; private set; }
    
    private bool speedEffectActive => (int)_player.velocity.y <= _speedForEffect; 
    private bool zoomCameraStat => (int)_player.velocity.y <= _speedForCamScale;   
    
    private void Awake()
    {
        _inputPanel = FindObjectOfType<InputPanel>();
        _inputPanel.OnDragEvent += InputPanelOnOnDragEvent;
        _speedEffect = FindObjectOfType<SpeedEffect>();
        _camera = FindObjectOfType<MainCamera>();
        _player = FindObjectOfType<Rigidbody2D>();
        yDiff = (_playerTuplePoint.position - transform.position).y;
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

    private void PlayerMaxSpeed()
    {
        if (_player.velocity.y < _maxFallDownSpeed)
        {
            _player.velocity = new Vector2(_player.velocity.x, _maxFallDownSpeed);
        }
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        _camera.SetCameraMinMaxValue(zoomCameraStat);
        _speedEffect.ChangeSpeedEffectStat(speedEffectActive);

        _inputVector.x = Input.GetAxisRaw("Horizontal");
        FlipPlayer();
        PlayerMaxSpeed();
    }
}
