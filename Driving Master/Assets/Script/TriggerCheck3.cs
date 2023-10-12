using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck3 : MonoBehaviour
{
    public Parking Parking;
    public Parking Parking2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Parking.isCollideWithTarget3 = true;
            Parking2.isCollideWithTarget3 = true;
            Debug.Log("Parked");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Parking.isCollideWithTarget3 = false;
        Parking2.isCollideWithTarget3 = false;
    }
}
