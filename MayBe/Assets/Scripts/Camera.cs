using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CharacterController _CharacterController;
    [SerializeField] private float _sensivity;
    [SerializeField] private float _mixAngle;
    [SerializeField] private float _maxAngle;
    [SerializeField] private Transform _transform;
    private Vector3 _localRotate;
    public bool HideCyrsor;

    private float horizontal;
    private float vertical;
    private void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
       // _localRotate = _camera.transform.localEulerAngles;
    }

    private void Update()
    {

        horizontal = _sensivity * Input.GetAxis("Mouse X") * Time.deltaTime;
        vertical = -_sensivity * Input.GetAxis("Mouse Y") * Time.deltaTime;
        //_localRotate.x = Mathf.Clamp(_localRotate.x + vertical, _mixAngle, _maxAngle);

        _transform.Rotate(horizontal * Vector3.up);
        //_camera.transform.localEulerAngles = _localRotate;
    }
}
