using UnityEngine;
using UnityEngine.AI;

public class Enemie : MonoBehaviour
{
    [SerializeField] private int HP = 100;

    private Animator animator;
    private NavMeshAgent navAgent;
    private Transform player;
    private float rotationSpeed = 30f;
    private EnemyWeapon enemyWeapon;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = Camera.main.transform;
        enemyWeapon = GetComponent<EnemyWeapon>();
        InvokeRepeating("Shoot",1f,5f);
    }


    private void Shoot()
    {
        enemyWeapon.Fire();
    }




    // Update is called once per frame
    void Update()
    {
        // ������� ������� � ������
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // �������� ���������� �� ������
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);


        if (distanceToPlayer > navAgent.stoppingDistance)
        {
            navAgent.SetDestination(player.position);
        }
        else
        {
            // ������� ������ ����������� ������ ������
            transform.RotateAround(player.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

 

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP < 0)
            animator.SetTrigger("Die");
        else
            animator.SetTrigger("Damage");
        Debug.Log($"{HP}");

    }

}
