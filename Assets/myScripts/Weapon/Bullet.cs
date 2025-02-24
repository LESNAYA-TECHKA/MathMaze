using UnityEngine;

public class Bullet: MonoBehaviour
{
    private int bulletDamage;
    public Vector3 hitPlace;
    public Transform hitTransform;
    public Vector3 normal;

    public void BulletEffects(string unit, int bulletDamage)
    {
        this.bulletDamage = bulletDamage;
        switch(unit)
        {
            case "Player":
                //Debug.Log("Hit Player");\
                HitPlayer();
                break;
            case "Wall":
                //Debug.Log("Hit Wall");
                HitWall();
                break;
            case "Enemie":
                //Debug.Log("Hit Enemie");
                HitEnemie();
                break;
            default:
                break;
        }
    }


    private void HitPlayer()
    {
        var player = hitTransform.GetComponent<PlayerHealth>();
        player.TakeDamage(bulletDamage);
    }


    private void HitEnemie()
    {
        var enemie = hitTransform.GetComponentInParent<Enemie>();
        enemie.TakeDamage(bulletDamage);
    }


    private void HitWall()
    {
        // Используем hitPlace (точка попадания) и нормаль из RaycastHit
        GameObject hole = Instantiate(
            GlobalReferences.instance.bulletEffectsPrefab,
            hitPlace + normal * 0.01f,
            Quaternion.LookRotation(normal)
        );

        // Прикрепляем эффект к объекту, в который попали
        hole.transform.SetParent(hitTransform);
        //Debug.Log(hitTransform);
    }






















    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        Debug.Log($"HIT {collision.gameObject.name} !");
    //        CreateBulletImpactEffect(collision);
    //        Destroy(gameObject);
    //    }

    //    if (collision.gameObject.CompareTag("Enemie"))
    //    {
    //        collision.gameObject.GetComponent<Enemie>().TakeDamage(bulletDamage);
    //        Destroy(gameObject);
    //    }

    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Hit Character");
    //    }

    //}

    //private void CreateBulletImpactEffect(Collision objectHit)
    //{
    //    ContactPoint contact = objectHit.GetContact(0);

    //    GameObject hole = Instantiate(
    //        GlobalReferences.instance.bulletEffectsPrefab,
    //        contact.point,
    //        Quaternion.LookRotation(contact.normal)
    //        );


    //    hole.transform.SetParent(objectHit.gameObject.transform);

    //}

}
