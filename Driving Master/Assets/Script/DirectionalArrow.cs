using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField] private Transform target;
    void Update()
    {
       /* Vector3 targetPosition = target.transform.position;
        targetPosition.y = transform.position.y;*/
       transform.LookAt(target);
       
    }
}
