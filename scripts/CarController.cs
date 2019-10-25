using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        WheelHubFrontLeft.steerAngle = m_steeringAngle;
        WheelHubFrontRight.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        float accelerate = 300f;
        WheelHubFrontLeft.motorTorque = m_verticalInput * motorForce * accelerate;
        WheelHubFrontRight.motorTorque = m_verticalInput * motorForce * accelerate;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(WheelHubFrontLeft, WheelFrontLeft);
        UpdateWheelPose(WheelHubFrontRight, WheelFrontRight);
        UpdateWheelPose(WheelHubRearLeft, WheelRearLeft);
        UpdateWheelPose(WheelHubRearRight, WheelRearRight);
        
    }
    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position * Time.deltaTime;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider WheelHubFrontLeft, WheelHubFrontRight;
    public WheelCollider WheelHubRearLeft, WheelHubRearRight;
    public Transform WheelFrontLeft, WheelFrontRight;
    public Transform WheelRearLeft, WheelRearRight;
    public float maxSteerAngle = 40; 
    public float motorForce = 2000;

   
}
