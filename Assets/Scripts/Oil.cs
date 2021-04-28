using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")){
            
            other.GetComponentInParent<CarController>().SpeedUp();
        }
    }


}