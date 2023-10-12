using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pedestrians : MonoBehaviour
{
 
    public NavMeshAgent agent;
    public Animator animator;

    public GameObject Path;
    private Transform[] PathPoints;

    public int index = 0;
    public float minmumDistance = 1;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        PathPoints = new Transform[Path.transform.childCount];
        for(int i=0; i<PathPoints.Length; i++)
        {
            PathPoints[i] = Path.transform.GetChild(i);
        }
    }
    private void Update()
    {
        room();
    }
    void room()
    {
        if (Vector3.Distance(transform.position, PathPoints[index].position) < minmumDistance)
        {
            if (index >=0 && index < PathPoints.Length)
            {
                index += 1;
            }
            else
            {
                index = 0;
            }
        }

        agent.SetDestination(PathPoints[index].position);
        animator.SetFloat("vertical", !agent.isStopped ? 1 : 0);
    }

}
