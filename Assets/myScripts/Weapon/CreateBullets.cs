using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CreateBullets : MonoBehaviour
{
    Weapon creator;
    int createBullets = 0;
    public CreateBullets(Weapon weapon, int numberOfBullets)
    {
        creator = weapon;
        createBullets = numberOfBullets;
    }


    public void CreateBulletsMethod()
    {
        if (creator.readyToShoot)
        {
            creator.readyToShoot = false;
            creator.StartCoroutine(Fire(createBullets));
        }
    }

    private IEnumerator Fire(int numBullets)
    {
            for (int i = 0; i < numBullets; i++)
            { 
                  if(creator.stopFire && numBullets > 1)
                  {
                      creator.stopFire = false;
                      creator.readyToShoot = true;
                      //creator.animator.SetTrigger("Stop");
                      yield break;
                  }
                  
                FireBullet();
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(creator.timeBetweenShots);
            creator.readyToShoot = true;
           // creator.animator.SetTrigger("Stop");
            creator.stopFire = false;
    }

    private void FireBullet()
    {
        if (creator.bulletsLeft != 0)
        {
            Vector3 shootingDirection = CaculateDirectionAndSpread().normalized;
            GameObject bullet = Instantiate(creator.bulletPrefab, creator.bulletSpawn.position, Quaternion.identity);
            bullet.transform.forward = shootingDirection;
            creator.animator.SetTrigger("Shoot");
            creator.soundSource.PlayOneShot(creator.mySounds.shoot);
            bullet.GetComponent<Rigidbody>().AddForce(creator.bulletSpawn.forward.normalized * creator.bulletVelocity, ForceMode.Impulse);
            creator.bulletsLeft--;
            creator.StartCoroutine(DestroyBulletAfterTime(bullet, creator.bulletLifeTime));
            creator.AmmoUpdate();
        }
        else
            creator.soundSource.PlayOneShot(creator.mySounds.empty);
  
    }
    private Vector3 CaculateDirectionAndSpread()
    {
        Ray ray = creator.playerCamera.ViewportPointToRay(new Vector3(1f, 1f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }

        Vector3 direction = targetPoint - creator.bulletSpawn.position;
        float z = UnityEngine.Random.Range(-creator.spreadIntensity, creator.spreadIntensity);
        float y = UnityEngine.Random.Range(-creator.spreadIntensity, creator.spreadIntensity);

        return new Vector3(0, y, z);
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

}
