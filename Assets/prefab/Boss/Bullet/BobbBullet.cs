using UnityEngine;

public class BobbBullet : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 10;
    private Vector3 direction = Vector3.forward;
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var tag = collision.gameObject.tag;

        switch(tag)
        {
            case "Wall":
                Destroy(this.gameObject);
                //Debug.Log("I hit");
                break;
            case "Player":
                //Debug.Log("pLAYER take dmg");
                var setDmg = collision.gameObject.GetComponent<PlayerHealth>();
                setDmg.TakeDamage(damage);
                Destroy(this.gameObject);
                break;
        }


    }

}
