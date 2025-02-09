using UnityEngine;

public class AutoShoot : IFireWeapon
{
    Weapon creator;
    CreateBullets bul;

    public AutoShoot(Weapon weap)
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
        if(creator.canShoot)

        {
            creator.stopFire = false;
            bul.CreateBulletsMethod();
        }
          
        

    }
}
