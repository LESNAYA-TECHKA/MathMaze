using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Camera playerCamera { get; private set; }
    public float spreadIntensity;
    public int bulletsPerBurst;
    public float bulletVelocity;
    public float bulletLifeTime = 3f;
    public bool readyToShoot = true;
    public float timeBetweenShots;
    public int magazineSize;
    public int bulletsLeft;
    public Animator animator;
    public IFireWeapon weapon;
    public bool stopFire = false;
    public bool canShoot = true;
    public int weaponDamage;
    public WeaponPosition myPosition;
    public WeaponSound mySounds;
    public AudioSource soundSource;

    public bool canSwitch = true;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
        playerCamera = Camera.main;
        readyToShoot = true;
        bulletsLeft = magazineSize;
    }


    public virtual void AmmoUpdate()
    {
        if (AmmoManager.instance.text != null)
            AmmoManager.instance.text.text = $"{bulletsLeft}/{magazineSize}";

    }


    public void SetWeapon(IFireWeapon weap)
    {
        weapon = weap;
    }

    public void Fire()
    {
        weapon.Fire();
    }

    public void StopFire()
    {
        animator.ResetTrigger("Shoot");
        animator.SetTrigger("Stop");
        stopFire = true;

    }


    public abstract void Reload();
  
}
//using System.Collections;
//using TMPro;
//using UnityEngine;

//public class Weapon : MonoBehaviour
//{
//    [SerializeField] private GameObject bulletPrefab;
//    [SerializeField] private Transform bulletSpawn;
//    [SerializeField] private float spreadIntensity;
//    [SerializeField] private int bulletsPerBurst = 3;
//    [SerializeField] private float bulletVelocity = 30f;
//    [SerializeField] private float bulletLifeTime = 3f;
//    [SerializeField] private int MaxBullets;
//    [SerializeField] private ShootingMode currentShootingMode;
//    [SerializeField] private Animator animator;
//    private Coroutine fireCoroutine;
//    private bool readyToShoot = true;
//    [SerializeField] float timeBetweenShots;
//    [SerializeField] private GameObject muzzleEffect;
//    [SerializeField] private float reloadTime;
//    [SerializeField] private int magazineSize;
//    [SerializeField] private int bulletsLeft;
//    [SerializeField] private bool isReloading;

//    private void Awake()
//    {
//        readyToShoot = true;
//        animator = GetComponent<Animator>();
//        bulletsLeft = magazineSize;
//    }


//    public void Update()
//    {
//        if (AmmoManager.instance.ammoDisplay != null)
//            AmmoManager.instance.ammoDisplay.text = $"{bulletsLeft}/{magazineSize}";
//    }


//    public void FireWeapon()
//    {
//        switch (currentShootingMode)
//        {
//            case ShootingMode.Singele:
//                if (readyToShoot)
//                {
//                    readyToShoot = false;
//                    StartCoroutine(Fire(1));
//                }
//                break;
//            case ShootingMode.Burst:
//                if (readyToShoot)
//                {
//                    readyToShoot = false;
//                    StartCoroutine(Fire(bulletsPerBurst));
//                }
//                break;
//            case ShootingMode.Auto:
//                if (readyToShoot && fireCoroutine == null)
//                {
//                    fireCoroutine = StartCoroutine(FireAuto());
//                }
//                break;
//        }
//    }

//    public void StopFiring()
//    {
//        if (fireCoroutine != null)
//        {
//            StopCoroutine(fireCoroutine);
//            fireCoroutine = null;
//            readyToShoot = true;
//        }
//    }

//    private IEnumerator Fire(int numBullets)
//    {
//        for (int i = 0; i < numBullets; i++)
//        {
//            FireBullet();
//            yield return new WaitForSeconds(0.05f);
//        }
//        yield return new WaitForSeconds(timeBetweenShots);
//        readyToShoot = true;
//    }



//    private IEnumerator FireAuto()
//    {
//        while (true)
//        {
//            FireBullet();
//            yield return new WaitForSeconds(0.1f); // Задержка между автоматическими выстрелами
//        }
//    }

//    private void FireBullet()
//    {
//        if (bulletsLeft == 0)
//            SoundManager.instance.Pistol_EmptyMagazine.Play();


//        if(bulletsLeft > 0)
//        {
//            animator.SetTrigger("Shoot");
//            muzzleEffect.GetComponent<ParticleSystem>().Play();
//            bulletsLeft--;
//            SoundManager.instance.Pistol_Shoot.Play();

//            Vector3 shootingDirection = CaculateDirectionAndSpread().normalized;
//            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
//            bullet.transform.forward = shootingDirection;
//            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);
//            StartCoroutine(DestroyBulletAfterTime(bullet, bulletLifeTime));

//        }

//    }

//    public void Reload()
//    {
//        if (!isReloading && bulletsLeft < magazineSize)
//        {
//            animator.SetTrigger("Reload");
//            SoundManager.instance.Pistol_Reload.Play();
//            isReloading = true;
//            Invoke("ReloadCompleted", reloadTime);
//        }

//    }

//    private void ReloadCompleted()
//    {
//        bulletsLeft = magazineSize;
//        isReloading = false;
//    }

//    private Vector3 CaculateDirectionAndSpread()
//    {
//        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
//        RaycastHit hit;
//        Vector3 targetPoint;
//        if (Physics.Raycast(ray, out hit))
//        {
//            targetPoint = hit.point;
//        }
//        else
//        {
//            targetPoint = ray.GetPoint(110);
//        }

//        Vector3 direction = targetPoint - bulletSpawn.position;
//        float x = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);
//        float y = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);

//        return direction + new Vector3(x, y, 0);
//    }

//    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
//    {
//        yield return new WaitForSeconds(delay);
//        Destroy(bullet);
//    }
//}
