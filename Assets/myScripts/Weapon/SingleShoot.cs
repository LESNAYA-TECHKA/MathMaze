using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;

public class SingleShoot : IFireWeapon
{

    Weapon creator;
    CreateBullets bul;

    public SingleShoot(Weapon weap)
    {
        creator = weap;
        CreateBul();
    }

    private void CreateBul()
    {
        bul = new CreateBullets(creator, creator.bulletsPerBurst);
    }


    public void Fire()
    {
        if (creator.canShoot)
        {
            creator.stopFire = false;
            bul.CreateBulletsMethod();
        }
    }

}
