using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    Animator animator;
    NavMeshAgent  nmAgent;
    GameObject target;

    enum ZombieState
    {
        run,
        attack,
        die,
        idle,
    }ZombieState zombiestate;
    

    float health;

    [SerializeField]
    ScoreManager scoremanager;
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
            zombiestate = ZombieState.die;
        else
        {
            Vector3 lookTarget = target.transform.position - gameObject.transform.position;
            var rotation = Quaternion.LookRotation(lookTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }

        switch(zombiestate)
        {
            case ZombieState.run:
            {
                nmAgent.SetDestination(target.transform.position);
                nmAgent.isStopped = false;
                animator.SetBool("run", true);
                break;
            }
            case ZombieState.attack:
            {
                nmAgent.isStopped = true;
                animator.SetTrigger("attack");
                break;
            }
            case ZombieState.die:
            {
                animator.SetTrigger("die");
                nmAgent.velocity = Vector3.zero;
                nmAgent.ResetPath();
                scoremanager.IncreaseScore();
                gameObject.transform.tag = "Dead_Zombie"; 
                Destroy(this);
                break;
            }
            case ZombieState.idle:
            {
                nmAgent.isStopped = true;
                nmAgent.velocity = Vector3.zero;
                animator.SetBool("idle", true);
                break;
            }
        }
        
    }

    public void TakeDamamge(float damamge)
    {
        health -= damamge;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            zombiestate = ZombieState.attack;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            zombiestate = ZombieState.attack;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        zombiestate = ZombieState.run;
    }

}
