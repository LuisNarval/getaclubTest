using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string BREAK = "Break";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBreakForce;
    private bool isBreaking;
    

    [Header("CONFIG")]
    [SerializeField] private float motorForce;
    [SerializeField] private float breakeForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private float Impulse = 10.0f;
    [SerializeField] private float SpeedUpTime = 2.0f;
    [SerializeField] private float SlideTime = 3.0f;


    [Header("REFERENCE")]
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [SerializeField] AudioSource[] SpeedSFX;
    [SerializeField] ParticleSystem[] SpeedParticles;
    [SerializeField] ParticleSystem SmokeParticle;
    [SerializeField] private Rigidbody Body;
    [SerializeField] private HUD Hud;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();

        UpdateHUD();
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        //isBreaking = Input.GetKey(KeyCode.Space);
    }

    void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        //currentBreakForce = isBreaking ? breakeForce : 0f;
        currentBreakForce = Input.GetAxis(BREAK) * breakeForce;

        if (Input.GetKey(KeyCode.E)) 
            SpeedUp();

        ApplyBreaking();
        
    }


    void ApplyBreaking()
    {
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        rearLeftWheelCollider.brakeTorque = currentBreakForce;
        rearRightWheelCollider.brakeTorque = currentBreakForce;
    }



    void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }


    void UpdateHUD()
    {
        Hud.updateSpeed(Body.velocity.magnitude);
    }

    




    public void SpeedUp()
    {
        StopAllCoroutines();
        StartCoroutine("C_SpeedUp");
       
    }
    IEnumerator C_SpeedUp()
    {
        float time = 0.0f;

        SmokeParticle.Stop();
        for (int i = 0; i < SpeedParticles.Length; i++)
            SpeedParticles[i].Play();

        for (int i = 0; i < SpeedSFX.Length; i++)
            SpeedSFX[i].Play();

        while (time < SpeedUpTime){
            Body.AddForce(this.transform.forward * Impulse, ForceMode.Acceleration);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        SmokeParticle.Play();
        for (int i = 0; i < SpeedParticles.Length; i++)
            SpeedParticles[i].Stop();
    }


}