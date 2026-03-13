using UnityEngine;
using UnityEngine.AI;

public class ClientOptions : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool IsGrounded = false;
    public LayerMask collision;
    RaycastHit hit;
    public Transform destination;


    private void Start()
    {
        agent.SetDestination(destination.gameObject.transform.position);
    }

}
