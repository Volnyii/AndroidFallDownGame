using System;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    // С буттонами наверняка не так нужно было

    private InputPanel _inputPanel;
    [SerializeField] private float _horizontalSpeed = 2f;
    [SerializeField] private int _maxVerticalSpeedForCam;
    [SerializeField] private int _maxVerticalSpeedForEffect;
    private MainCamera _camera;
    private SpeedEffect _speedEffect;
    private bool _isCameraZoomed;
    private bool _isSpeedEffectTurnedOn;
    private Rigidbody2D _player;
    private SpriteRenderer _playerSprite;

    private void Awake()
    {
        _inputPanel = FindObjectOfType<InputPanel>();
        _inputPanel.OnDragEvent += InputPanelOnOnDragEvent;
        _speedEffect = FindObjectOfType<SpeedEffect>();
        _camera = FindObjectOfType<MainCamera>();
        _player = GetComponent<Rigidbody2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
    }

    private void InputPanelOnOnDragEvent(float inputX)
    {
        var sign = Mathf.Sign(inputX);
        var resultSpeed = inputX == 0f ? 0f : _horizontalSpeed * sign;
        _player.velocity = new Vector2(resultSpeed * _horizontalSpeed, _player.velocity.y);
    }

    private bool ZoomCameraStat()
    {
        _isCameraZoomed = (int)_player.velocity.y > _maxVerticalSpeedForCam ? false : true;
        return _isCameraZoomed;
    }

    private bool SpeedEffectStat()
    {
        _isSpeedEffectTurnedOn = (int)_player.velocity.y > _maxVerticalSpeedForEffect ? false : true;
        return _isSpeedEffectTurnedOn;
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        _playerSprite.flipX = _player.position.x < 0; // Как правильно крутить игрока по х?
        _camera.CameraZoom(ZoomCameraStat(), Time.deltaTime);
        _speedEffect.ChangeSpeedEffectStat(SpeedEffectStat());
    }
}
