using UnityEngine;

public class Player : MonoBehaviour
{
    private InputPanel _inputPanel;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private int _speedForCamScale;
    [SerializeField] private int _speedForEffect;
    [SerializeField] private int _maxFallDownSpeed;
    private MainCamera _camera;
    private SpeedEffect _speedEffect;
    private bool _isCameraZoomed;
    private bool _isSpeedEffectTurnedOn;
    private Rigidbody2D _player;
    
    private Vector3 _inputVector;
    private bool _faceRight;

    private void Awake()
    {
        _inputPanel = FindObjectOfType<InputPanel>();
        _inputPanel.OnDragEvent += InputPanelOnOnDragEvent;
        _speedEffect = FindObjectOfType<SpeedEffect>();
        _camera = FindObjectOfType<MainCamera>();
        _player = GetComponent<Rigidbody2D>();
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

    private bool ZoomCameraStat()
    {
        _isCameraZoomed = (int)_player.velocity.y > _speedForCamScale ? false : true;
        return _isCameraZoomed;
    }

    private bool SpeedEffectStat()
    {
        _isSpeedEffectTurnedOn = (int)_player.velocity.y > _speedForEffect ? false : true;
        return _isSpeedEffectTurnedOn;
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
        _camera.CameraZoom(ZoomCameraStat(), Time.deltaTime);
        _speedEffect.ChangeSpeedEffectStat(SpeedEffectStat());

        _inputVector.x = Input.GetAxisRaw("Horizontal");
        FlipPlayer();
        PlayerMaxSpeed();
    }
}
