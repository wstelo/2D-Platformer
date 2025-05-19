using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]
public class Mover : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForceVertical;
    [SerializeField] private float _jumpForceHorizontal;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isJump = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(_isJump == false)
        {
            Move();
        }
    }

    public void OnEnable()
    {
        _inputService.EnterButtonClicked += Jump;
        _collisionDetector.Lended += Land;
    }

    public void OnDisable()
    {
        _inputService.EnterButtonClicked -= Jump;
        _collisionDetector.Lended -= Land;
    }

    private void Jump()
    {
        if (_collisionDetector.IsGrounded)
        {
            _rigidbody.AddForce(new Vector2(_inputService.Horizontal * _jumpForceHorizontal, _jumpForceVertical));
            _isJump = true;
            _animator.SetBool("isJump", true);
        }
    }

    private void Land()
    {
        if (_isJump == true)
        {
            _isJump = false;
            _animator.SetBool("isJump", false);
        }
    }

    private void Move()
    {
        float horizontalDirection = _inputService.Horizontal;
        _animator.SetFloat("Speed", Mathf.Abs(horizontalDirection));

        if (horizontalDirection < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (horizontalDirection > 0)
        {
            _spriteRenderer.flipX = false;
        }

        transform.Translate(new Vector3(horizontalDirection * _moveSpeed * Time.deltaTime, 0));
    }
}
