using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _movingXBody;
    [SerializeField] private Rigidbody2D _rotatingBody;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private TriggerZone _triggerZone;
    
    [Inject] private GameController _gameController;
    
    private InputPanel _inputPanel;

    private void Awake()
    {
        _inputPanel = FindObjectOfType<InputPanel>(true);
        _inputPanel.OnDragEvent += InputPanelOnOnDragEvent;
        _triggerZone.OnPlayerInside += TriggerZoneOnOnPlayerInside;
    }

    private void TriggerZoneOnOnPlayerInside(GameItem gameItem)
    {
        _gameController.Info.ScoreInfo.ChangeScore(gameItem.Value, gameItem.ObjectType);
    }
    
    private void InputPanelOnOnDragEvent(float inputX)
    {
        var sign = Mathf.Sign(inputX);
        var resultSpeed = inputX == 0f ? 0f : _horizontalSpeed * sign;

        _movingXBody.position += new Vector3(resultSpeed, 0f, 0f);
        if(resultSpeed == 0)
            return;

        _playerSprite.flipX = resultSpeed < 0;
    }
}
