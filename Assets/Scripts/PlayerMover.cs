using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float _speed = 3f;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private float _xAxis = 0f;
    private float _yAxis = 0f;
    private Rigidbody2D _rigidbody2D;
    

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponentInChildren<PlayerAnimator>();

        if (_playerAnimator == null)
            Debug.LogWarning($"[{nameof(PlayerMover)}] PlayerAnimator не найден у дочерних объектов {gameObject.name}");
    }

    private void Update()
    {
        ReadInput();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        if (_xAxis != 0.0f || _yAxis != 0f)
            Move(_xAxis, _yAxis);
    }

    private void ReadInput()
    {
        _xAxis = Input.GetAxisRaw(Horizontal);
        _yAxis = Input.GetAxisRaw(Vertical);
    }

    private void Move(float x, float y)
    {
        Vector3 direction = (transform.right * x + transform.up * y).normalized;
        _rigidbody2D.MovePosition(transform.position + direction * _speed * Time.fixedDeltaTime);
    }

    private void UpdateAnimation()
    {
        bool isWalking = _xAxis != 0f || _yAxis != 0f;
        _playerAnimator.SetWalking(isWalking);
    }
}
