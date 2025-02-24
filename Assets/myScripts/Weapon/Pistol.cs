using System.Collections;
using UnityEngine;

public class Pistol : Weapon
{
    private void Start()
    {
        bullerSpawnPosition = Camera.main.gameObject;
    }


    public Pistol()
    {
        timeBetweenShots = 0.5f;
        magazineSize = 7;
        spreadIntensity = 1.5f;
        //how many bullets we shoot
        bulletsPerBurst = 1;
        timeBetweenShots = 0f;
        weaponDamage = 20;
        weapon = new SingleShoot(this); 
    }


    public override void Reload()
    {
        if (canShoot)
        {
            canSwitch = false;
            canShoot = false;
            animator.SetTrigger("Reload");
            StartCoroutine(ReloadCoroutine());
        }

    
       
    }

    private IEnumerator ReloadCoroutine()
    {
        // Ждём 1.15 секунды
        yield return new WaitForSeconds(2f);
        bulletsLeft = magazineSize; // Перезарядка
        AmmoUpdate(); // Обновляем количество патронов
        canShoot = true;
        canSwitch = true;
    }

}
