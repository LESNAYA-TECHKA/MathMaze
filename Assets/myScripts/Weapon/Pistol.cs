using System.Collections;
using UnityEngine;

public class Pistol : Weapon
{

    public Pistol()
    {
        timeBetweenShots = 0.5f;
        magazineSize = 7;
        spreadIntensity = 0.1f;
        //how many bullets we shoot
        bulletsPerBurst = 1;
        bulletVelocity = 500;
        timeBetweenShots = 0f;
        weapon = new SingleShoot(this);
        
    }



    public override void Reload()
    {
        canSwitch = false;
        canShoot = false;
        animator.SetTrigger("Reload");
        StartCoroutine(ReloadCoroutine());       
       
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
