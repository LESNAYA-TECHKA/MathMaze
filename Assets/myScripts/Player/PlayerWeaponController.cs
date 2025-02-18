using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerWeaponController : MonoBehaviour
{
    //if you need to implement the selection of weapons from the ground, uncomment the compromised code.
    public static PlayerWeaponController instance { get; private set; }

    [SerializeField] private List<GameObject> weaponSlots;

    private Weapon weaponSlot1;
    private Weapon weaponSlot2;
    private bool firstSlotIsActive;
    private bool canSwitch; 

    //It was used with the selection of weapons
    /*
    private bool isWeapon = false;
    private float maxDistance = 1.8f;
    private int weaponLayerMask; // Создаём маску для слоя "Weapon"

    private Outline selected;
    private GameObject canTake;
    */


    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        weaponSlot1 = weaponSlots[0].GetComponentInChildren<Weapon>();
        weaponSlot2 = weaponSlots[1].GetComponentInChildren<Weapon>();
        canSwitch = true;
    }

    private void Start()
    {
        //It was used with the selection of weapons
        //weaponLayerMask = LayerMask.GetMask("Weapon");

        firstSlotIsActive = true;
        weaponSlots[1].gameObject.SetActive(false);
        weaponSlot1.AmmoUpdate();

        //It was used with the selection of weapons
        //InvokeRepeating(nameof(CheckForWeapon), 0f, 0.15f);

    }


    //it works, but I decided not to use it. Can take any Weapon.
    /*
    private void CheckForWeapon()
    {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Рисуем луч в сцене для отладки
        //Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red);

        // Raycast с ограниченной дальностью
        if (Physics.Raycast(ray, out hit, maxDistance, weaponLayerMask))
        {
            GameObject hitGameObject = hit.transform.gameObject;
            canTake = hitGameObject;

            if (hitGameObject.GetComponent<Weapon>())
            {
                isWeapon = true;
                GlobalReferences.instance.pressButtonToTakeWeapon.gameObject.SetActive(true);

                selected = hitGameObject.GetComponent<Outline>();
                selected.enabled = true;
            
                //Debug.Log("Попадание по оружию!");
            }
            //else
            //    hitGameObject.GetComponent<Outline>().enabled = false;

        }
        else
        {
            if(isWeapon)
                  selected.enabled = false;
            isWeapon = false;
            GlobalReferences.instance.pressButtonToTakeWeapon.gameObject.SetActive(false);
            //Debug.Log("Не оружие");
        }
    }

    private void DropWeapon()
    {
        var activeWeaponSlot = firstSlotIsActive? weaponSlots[0]: weaponSlots[1];

        try
        {
            var anim = activeWeaponSlot.gameObject.GetComponentInChildren<Animator>();
            anim.enabled = false;


        }
        catch
        {

            Debug.Log("Ni animator on gun");
        
        }

        var weaponToDrop = activeWeaponSlot.transform.GetChild(0).gameObject;
        weaponToDrop.transform.SetParent(canTake.transform.parent);
        weaponToDrop.transform.localPosition = canTake.transform.localPosition;
        weaponToDrop.transform.localRotation = canTake.transform.localRotation;


    }
    public void TakeWeapon()
    {
        if (isWeapon)
        {
            DropWeapon();
            var whereTransform = firstSlotIsActive ? weaponSlots[0].transform : weaponSlots[1].transform;
            canTake.transform.SetParent(whereTransform,false);
            Weapon w = canTake.GetComponent<Weapon>();
            w.transform.localPosition = w.myPosition.position;
            w.transform.localRotation = Quaternion.Euler(w.myPosition.rotatex, w.myPosition.rotatey, w.myPosition.rotatez);
            w.animator.enabled = true;
            if (firstSlotIsActive)
            {
                weaponSlot1 = weaponSlots[0].GetComponentInChildren<Weapon>();
                w.AmmoUpdate();
                canTake.GetComponent<Outline>().enabled = false;
            }
            else
            {
                weaponSlot2 = weaponSlots[1].GetComponentInChildren<Weapon>();
                w.AmmoUpdate();

                canTake.GetComponent<Outline>().enabled = false;
            }
        }

    }

    */

    public void SelectNextSlot()
    {
        if (!canSwitch)
            return;

        if (firstSlotIsActive && weaponSlot1.canSwitch)
        {
            weaponSlots[0].gameObject.SetActive(false);
            weaponSlots[1].gameObject.SetActive(true);
            weaponSlot2 = weaponSlots[1].GetComponentInChildren<Weapon>();
            weaponSlot2.AmmoUpdate();
            weaponSlot1.readyToShoot = true;
            firstSlotIsActive = false;
        }
        else if(!firstSlotIsActive && weaponSlot2.canSwitch)
        {
            weaponSlots[0].gameObject.SetActive(true);
            weaponSlots[1].gameObject.SetActive(false);
            weaponSlot1 = weaponSlots[0].GetComponentInChildren<Weapon>();
            weaponSlot1.AmmoUpdate();
            weaponSlot2.readyToShoot = true;
            firstSlotIsActive = true;

        }
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        canSwitch = false; 
        yield return new WaitForSeconds(1f); // Ждем 1 секунду
        canSwitch = true; // Разблокируем смену оружия
    }

    public void Fire()
    {
        if (firstSlotIsActive)
            weaponSlot1.Fire();
        else
            weaponSlot2.Fire();
    }

    public void Reload()
    {
        if (firstSlotIsActive)
            weaponSlot1.Reload();
        else
            weaponSlot2.Reload();
    }

    public void StopFire()
    {
        if (firstSlotIsActive)
        {
            weaponSlot1.StopFire();
        }
            
        else
        {
            weaponSlot2.StopFire();
        }
            
    }


}
