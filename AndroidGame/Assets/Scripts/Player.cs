using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    // С буттонами наверняка не так нужно было
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
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
        _speedEffect = FindObjectOfType<SpeedEffect>();
        _camera = FindObjectOfType<MainCamera>();
        _player = GetComponent<Rigidbody2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
    }
    
    public void PlayerMove(float x)
    {
        // Сюда нужно добавить управление при таче по кнопкам right и left
        _player.velocity = new Vector2(x * _horizontalSpeed, _player.velocity.y);
    }

    private bool ZoomCameraStat()
    {
        _isCameraZoomed = (int)_player.velocity.y > _maxVerticalSpeedForCam ? false : true;
        print(_isCameraZoomed);
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
        PlayerMove(x);
        _camera.CameraZoom(ZoomCameraStat(), Time.deltaTime);
        _speedEffect.ChangeSpeedEffectStat(SpeedEffectStat());
    }
}
