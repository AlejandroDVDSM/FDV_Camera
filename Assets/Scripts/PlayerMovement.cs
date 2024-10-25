using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10.0f;
    
    private float _horizontalMovement;
    private Vector3 _direction;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (_horizontalMovement != 0)
        {
            _spriteRenderer.flipX = _horizontalMovement > 0;
            _direction = new Vector3(_horizontalMovement, 0, 0).normalized;
        }
    }

    private void FixedUpdate()
    {
        if (_horizontalMovement != 0)
            _rigidbody2D.MovePosition(transform.position + _direction * (_moveSpeed * Time.fixedDeltaTime));
    }
}