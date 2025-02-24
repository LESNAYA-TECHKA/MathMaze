using System.Collections;
using UnityEngine;

public class Ak_47:Weapon
{
    public Ak_47()
    {
        timeBetweenShots = 0.01f;
        magazineSize = 30;
        spreadIntensity = 2f;
        //how many bullets we shoot
        bulletsPerBurst = 30;
        timeBetweenShots = 0.1f;
        weaponDamage = 10;
        weapon = new AutoShoot(this);
    }



    public override void Reload()
    {
        if(canShoot)
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
