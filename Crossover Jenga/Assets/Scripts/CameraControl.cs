using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _cameraMoveSpeed = 1;

    [SerializeField] private Transform[] _towerPositions;

    [SerializeField] private Transform _tower2AimPoint;

    private int _currentPosition = 1;

    private bool _moving = false;

    private Vector3 _cameraStartRotation;

    // Start is called before the first frame update
    void Start()
    {
        _cameraStartRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        float rotateAngle;
        
        if(_moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _towerPositions[_currentPosition].position, _cameraMoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _towerPositions[_currentPosition].position) < 0.1f)
            {
                _moving = false;
               
            }
            return;
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(_currentPosition > 0)
            {
                _moving = true;
                _currentPosition--;
                transform.rotation = Quaternion.Euler(_cameraStartRotation);
            }

        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(_currentPosition < 2)
            {
                _moving = true;
                _currentPosition++;
                transform.rotation = Quaternion.Euler(_cameraStartRotation);
            }
        }
       
        if(Input.GetMouseButton(0))
        {
            rotateAngle = Input.GetAxis("Mouse X");
            Debug.Log("MOUSE: " + rotateAngle);
            transform.RotateAround(_tower2AimPoint.position, Vector3.up, rotateAngle);
        }
       
    }
}
