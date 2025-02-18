using UnityEngine;

public class EnemyWeapon : Weapon
{
    public EnemyWeapon()
    {
        timeBetweenShots = 0.01f;
        magazineSize = int.MaxValue;
        spreadIntensity = 2f;
        //how many bullets we shoot
        bulletsPerBurst = 1;
        bulletVelocity = 10;
        timeBetweenShots = 0.1f;
        weaponDamage = 10;
        weapon = new SingleShoot(this);
    }

    public override void AmmoUpdate()
    {
       
    }

    public override void Reload()
    {
        
    }
}
