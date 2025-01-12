using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    Animator animator;
    NavMeshAgent  nmAgent;
    GameObject target;

    float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        nmAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
            return;
        else
        {
            Vector3 lookTarget = target.transform.position - gameObject.transform.position;
            var rotation = Quaternion.LookRotation(lookTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
            if ((gameObject.transform.position - target.transform.position).sqrMagnitude <= 1f)
            {
                print("attacking the player");
                nmAgent.isStopped = true;
                animator.SetTrigger("attack");
            }
            else
            {
                nmAgent.SetDestination(target.transform.position);
                nmAgent.isStopped = false;
                animator.SetBool("run", true);
            }
        }
    }

    public void TakeDamamge(float damamge)
    {
        if (health <= 0f)
        {
            animator.SetTrigger("die");
            nmAgent.velocity = Vector3.zero;
            nmAgent.ResetPath();
        }
        else
        {
            health -= damamge;
        }
        
    }
}
