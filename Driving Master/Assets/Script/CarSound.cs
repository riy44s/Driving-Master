using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    AudioSource audioSource;

    public float minPath = 0.05f;
    private float pitchFromCar;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPath;
    }

   
    void Update()
    {
        pitchFromCar = Car.car.carCurrentSpeed;
  
        if(pitchFromCar < minPath)
        {
            audioSource.pitch = minPath;
        }
        else
        {
            audioSource.pitch = pitchFromCar;
        }
       
    }
}
