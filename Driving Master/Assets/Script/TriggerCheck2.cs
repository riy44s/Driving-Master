using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck2 : MonoBehaviour
{
    public Parking Parking;
    public Parking Parking2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Parking.isCollideWithTarget2 = true;
            Parking2.isCollideWithTarget2 = true;
            Debug.Log("Parked");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Parking.isCollideWithTarget2 = false;
        Parking2.isCollideWithTarget2 = false;
    }

}