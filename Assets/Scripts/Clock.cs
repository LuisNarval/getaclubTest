using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] int SecondsToAdd;
    [SerializeField] ParticleSystem Explotion;

    private Timer timer;

    private void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            timer.addTime(SecondsToAdd);

            this.GetComponent<Animator>().enabled = false;
            Vector3 CurrentPosition = Explotion.transform.position;
            this.transform.position = new Vector3(10000, 10000, 10000);
            Explotion.transform.position = CurrentPosition;
            Explotion.Play();
        }
    }

}