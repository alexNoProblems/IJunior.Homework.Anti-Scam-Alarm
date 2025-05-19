using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private InputReader _inputReader;

    private Rigidbody2D _rigidbody2D;
    private bool _wasWalking;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        Vector2 movement = _inputReader.Movement;

        if (movement != Vector2.zero)
            Move(movement);
    }

    private void Move(Vector2 direction)
    {
        Vector3 moveVector = new Vector3(direction.x, direction.y, 0);
        _rigidbody2D.MovePosition(transform.position + moveVector * _speed * Time.fixedDeltaTime);
    }

    private void UpdateAnimation()
    {
        bool isWalking = _inputReader.Movement != Vector2.zero;

        if (_wasWalking != isWalking)
        {
            _playerAnimator.SetWalking(isWalking);
            _wasWalking = isWalking;
        }
    }
}
