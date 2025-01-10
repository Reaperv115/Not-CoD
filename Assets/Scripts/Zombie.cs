using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    Animator animator;
    NavMeshAgent  nmAgent;
    GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        nmAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject.transform.position - target.transform.position).sqrMagnitude <= 1f)
        {
            print("attacking the player");
            nmAgent.isStopped = true;
        }
        else
        {
            nmAgent.SetDestination(target.transform.position);
            nmAgent.isStopped = false;
        }
    }
}
