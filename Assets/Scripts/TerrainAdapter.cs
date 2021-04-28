using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainAdapter : MonoBehaviour
{
    [SerializeField] WheelCollider[] Wheels;
    [SerializeField] float SlideTime = 3.0f;
    [SerializeField] float BreakTime = 1.0f;
    [SerializeField] float BreakForce = 3000.0f;

    void ChangeStiffnes(WheelCollider _wheel, float _forwardValue, float _sideValue)
    {
        WheelFrictionCurve fFriction = _wheel.forwardFriction;
        WheelFrictionCurve sFriction = _wheel.sidewaysFriction;

        fFriction.stiffness = _forwardValue;
        sFriction.stiffness = _sideValue;

        _wheel.forwardFriction = fFriction;
        _wheel.sidewaysFriction = sFriction;
    }

    void Normalize()
    {
        for (int i = 0; i < Wheels.Length; i++)
            ChangeStiffnes(Wheels[i], 1.0f, 1.0f);
    }



    void Slide()
    {
        StopCoroutine("C_Slide");
        StartCoroutine("C_Slide");

    }
    IEnumerator C_Slide()
    {
        for (int i = 0; i < Wheels.Length; i++)
            ChangeStiffnes(Wheels[i], 5.0f, 0.2f);
        
        yield return new WaitForSeconds(SlideTime);
        Normalize();
    }


    void EnterSand()
    {
        for (int i = 0; i < Wheels.Length; i++)
            ChangeStiffnes(Wheels[i], 0.05f, 1.0f);

        //for (int i = 0; i < Wheels.Length; i++)
        //  Wheels[i].brakeTorque= 1000000;
        StartCoroutine(C_Breaks());
    
    }

    IEnumerator C_Breaks()
    {
        float time = 0.0f;
        while (time < BreakTime){
            for (int i = 0; i < Wheels.Length; i++)
                Wheels[i].brakeTorque = BreakForce;

            yield return new WaitForEndOfFrame();
        }
    }






    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Oil":
                Slide();
                break;

            case "Sand":
                EnterSand();
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Sand":
                Normalize();
                break;
        }
    }


}