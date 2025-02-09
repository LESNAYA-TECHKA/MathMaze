using UnityEngine;

public class BurstShoot: IFireWeapon
{

    Weapon creator;
    CreateBullets bul;

    public BurstShoot(Weapon weap)
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
            bul.CreateBulletsMethod();
    }
}
