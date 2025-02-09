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
        bulletVelocity = 500;
        timeBetweenShots = 0.1f;
        weapon = new AutoShoot(this);

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
        // ��� 1.15 �������
        yield return new WaitForSeconds(2f);

        bulletsLeft = magazineSize; // �����������
        AmmoUpdate(); // ��������� ���������� ��������
        canShoot = true;
        canSwitch = true;
    }
}
