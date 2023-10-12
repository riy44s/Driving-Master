using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    public float safeDistance = 2f;
    public float carSpeed = 5f;

    private NavMeshAgent carNavMesh;
    private SpawnCar spawnCarScript;
    private void Start()
    {
        carNavMesh = this.gameObject.GetComponent<NavMeshAgent>();
        carNavMesh.speed = carSpeed;
    }
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, safeDistance); 

        if (hit.transform)
        {
            if(hit.transform.tag == "CarAI")
            {
                Stop();
            }
            if (hit.transform.gameObject)
            {
                Destroy(gameObject);
            }
        }
        else
        {  
            Move();
        }
    }
 
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x,transform.position.y,transform.position.z +safeDistance));
    }
    void Stop()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    void Move()
    {
        transform.position += new Vector3(carSpeed * Time.deltaTime, 0,0);
 
    }
}
