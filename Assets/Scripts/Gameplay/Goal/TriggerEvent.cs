using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] UnityEvent m_OnTriggerEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            m_OnTriggerEnter.Invoke();
    }
}