using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Vector3 _jumpStrenght;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _croachSpeed;
    [SerializeField] private float _croachSize;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private Transform _foot;
    private bool _isGrounded => Physics.CheckSphere(_foot.transform.position, _footSize, _layerMask);
    [SerializeField] private float _footSize;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] private Vector3 _gravity;

    private bool _isMoving = true;
    private bool _canJump;
    private Vector3 _movementDirection;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (_isMoving)
        {
            var direction = _characterController.transform.forward * _movementSpeed * Input.GetAxis("Vertical");
            direction += _characterController.transform.right * _movementSpeed * Input.GetAxis("Horizontal");
            _movementDirection = direction;

            _movementDirection.x = Mathf.Clamp(_movementDirection.x, _minSpeed, _maxSpeed);
            _movementDirection.y = Mathf.Clamp(_movementDirection.y, _minSpeed, _maxSpeed);
            _movementDirection.z = Mathf.Clamp(_movementDirection.z, _minSpeed, _maxSpeed);

            if(!_isGrounded)
            {
                _movementDirection -= _gravity * Time.deltaTime;
            } else
            {
                _movementDirection.y = _minSpeed;
                if (Input.GetAxis("Jump") == 1f)
                {
                    _movementDirection = (_jumpStrenght * Time.deltaTime * Time.deltaTime) / 2f;
                }
            }

            _characterController.Move(_movementDirection);
        }
    }
}
