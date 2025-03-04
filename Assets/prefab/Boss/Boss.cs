using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] private Slider HpSlider;
    [SerializeField] private EnemySounds sounds;
    [SerializeField] private GameObject body;
    [SerializeField] private Transform[] spawns;

    private Animator animator;
    private float rotationSpeed = 5f;
    private bool Alive = true;

    void Start()
    {
        HpSlider.value = 500;
        animator = GetComponent<Animator>();
        //InvokeRepeating("Shoot", 1f, 5f);

    }


    private void Shoot()
    {

    }




    // Update is called once per frame
    void LateUpdate()
    {
        body.transform.Rotate(Vector3.up * rotationSpeed *Time.deltaTime, Space.World);
    }



    public void TakeDamage(int damageAmount)
    {
        HpSlider.value -= damageAmount;

        if (HpSlider.value <= 0)
            Die();
        else
            animator.SetTrigger("Damage");
        // Debug.Log($"{HpSlider.value}");

    }

    private void Die()
    {
        if (Alive)
        {
            Alive = false;
            animator.SetTrigger("Die");
        }

    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
