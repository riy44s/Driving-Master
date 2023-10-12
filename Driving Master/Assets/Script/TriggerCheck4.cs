using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck4 : MonoBehaviour
{
    public Parking Parking;
    public Parking Parking2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Parking.isCollideWithTarget4 = true;
            Parking2.isCollideWithTarget4 = true;
            Debug.Log("Parked");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Parking.isCollideWithTarget4 = false;
        Parking2.isCollideWithTarget4 = false;
    }
}
