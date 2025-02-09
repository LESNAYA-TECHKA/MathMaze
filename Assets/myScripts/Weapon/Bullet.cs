using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log($"HIT {collision.gameObject.name} !");
            CreateBulletImpactEffect(collision);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log($"HIT {collision.gameObject.name} !");
            CreateBulletImpactEffect(collision);
            Destroy(gameObject);
        }
    }

    private void CreateBulletImpactEffect(Collision objectHit)
    {
        ContactPoint contact = objectHit.GetContact(0);

        GameObject hole = Instantiate(
            GlobalReferences.instance.bulletEffectsPrefab,
            contact.point,
            Quaternion.LookRotation(contact.normal)
            );


        hole.transform.SetParent(objectHit.gameObject.transform);

    }

}
