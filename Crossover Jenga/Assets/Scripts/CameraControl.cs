
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _cameraMoveSpeed = 1;

    [SerializeField] private Transform[] _towerPositions;

    [SerializeField] private Transform _tower1AimPoint;
    [SerializeField] private Transform _tower2AimPoint;
    [SerializeField] private Transform _tower3AimPoint;

    private int _currentPosition = 1;

    private bool _moving = false;

    private Vector3 _cameraStartRotation;

    private Transform _currentAimPoint;
   
    void Start()
    {
        _cameraStartRotation = transform.rotation.eulerAngles;
        _currentAimPoint = _tower2AimPoint;
    }

   
    void Update()
    {
        float rotateAngle;
        
        if(_moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _towerPositions[_currentPosition].position, _cameraMoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _towerPositions[_currentPosition].position) < 0.1f)
            {
                _moving = false;
               
                switch(_currentPosition)
                {
                    case 0:
                        _currentAimPoint = _tower1AimPoint;
                        break;
                    case 1:
                        _currentAimPoint = _tower2AimPoint;
                        break;
                    case 2:
                        _currentAimPoint = _tower3AimPoint;
                        break;
                    default:
                        break;
                }

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
            
            transform.RotateAround(_currentAimPoint.position, Vector3.up, rotateAngle);
        }
       
    }
}
