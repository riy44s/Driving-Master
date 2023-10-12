using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public Parking Parking;
    public Parking parking2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Parking.isCollideWithTarget = true;
            parking2.isCollideWithTarget = true;
            Debug.Log("Parked");
        }
    }
    private void OnTriggerExit(Collider other)
    {

        Parking.isCollideWithTarget = false;
        parking2.isCollideWithTarget = false;
        Debug.Log("not parked");
    }
}
