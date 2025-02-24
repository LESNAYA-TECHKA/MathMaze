using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CreateBullets
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
                      creator.animator.SetTrigger("Stop");
                      yield break;
                  }
                  
                FireBullet();
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(creator.timeBetweenShots);
            creator.readyToShoot = true;
            creator.animator.SetTrigger("Stop");
            creator.stopFire = false;
    }

    private void FireBullet()
    {
        if (creator.bulletsLeft != 0)
        {

            //GameObject bullet = Instantiate(creator.bulletPrefab, creator.bulletSpawn.position, Quaternion.identity);
            //var bulletDamage = bullet.GetComponent<Bullet>().bulletDamage = creator.weaponDamage;
            //bullet.transform.forward = shootingDirection;

            //bullet.GetComponent<Rigidbody>().AddForce(creator.bulletSpawn.forward.normalized * creator.bulletVelocity, ForceMode.Impulse);

            //creator.StartCoroutine(DestroyBulletAfterTime(bullet, creator.bulletLifeTime));

            Camera camera = Camera.main;

            Vector3 shootingDirection = CaculateDirectionAndSpread(camera);
            Ray ray = new Ray(creator.bullerSpawnPosition.transform.position, shootingDirection);
            RaycastHit hit;
            creator.animator.SetTrigger("Shoot");
            creator.soundSource.PlayOneShot(creator.mySounds.shoot);
            creator.bulletsLeft--;
            creator.AmmoUpdate();
            // ѕровер€ем, есть ли столкновение с чем-либо
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                var hitTransform = hit.transform;
                var whereWasHit = hit.point;
                var normal = hit.normal;
                Bullet bullet = new Bullet();
                bullet.hitPlace = whereWasHit;
                bullet.hitTransform = hitTransform;
                bullet.normal = normal;
                bullet.BulletEffects(hit.collider.tag,creator.weaponDamage);
                Debug.Log(hit.collider.tag);
            }
        }
        else
            creator.soundSource.PlayOneShot(creator.mySounds.empty);
  
    }
    private Vector3 CaculateDirectionAndSpread(Camera cam)
    {
        // ”меньшаем диапазон случайного смещени€
        float spreadFactor = 0.01f; //дл€ контрол€ интенсивности разброса
        float x = UnityEngine.Random.Range(-creator.spreadIntensity, creator.spreadIntensity) * spreadFactor;
        float y = UnityEngine.Random.Range(-creator.spreadIntensity, creator.spreadIntensity) * spreadFactor;

        // ѕолучаем направление взгл€да камеры
        Vector3 cameraForward = creator.bullerSpawnPosition.transform.forward;

        // —оздаем случайное смещение относительно направлени€ камеры
        Vector3 spreadDirection = new Vector3(x, y, 0);

        // ƒобавл€ем смещение к направлению камеры и нормализуем результат
        Vector3 shootingDirection = (cameraForward + spreadDirection).normalized;

        return shootingDirection;
    }

    //private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    Destroy(bullet);
    //}

}
