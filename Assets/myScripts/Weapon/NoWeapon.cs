using UnityEngine;

public class NoWeapon : Weapon
{
    public NoWeapon()
    { 
    
       weapon = new DontHaveWeapon();
    
    }

    public override void Reload()
    {
        
    }


}
