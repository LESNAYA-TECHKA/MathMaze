using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputs : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.PlayerOnGroundActions onGround;
    private PlayerController playerControll;
    private PlayerLook look;
    //private Pistol weapon;
    private void Awake()
    {
        playerInput = new PlayerInput();
        look = GetComponent<PlayerLook>();
        //weapon = GetComponentInChildren<Pistol>();
        playerControll = GetComponent<PlayerController>();
        onGround = playerInput.PlayerOnGround;
        onGround.Jump.performed += ctx => playerControll.Jump();
        onGround.sprint.performed += ctx => playerControll.Sprint();
        onGround.sprint.canceled += ctx => playerControll.NormalMove();
        onGround.shoot.started += ctx => PlayerWeaponController.instance.Fire();
        onGround.shoot.canceled += ctx => PlayerWeaponController.instance.StopFire();
        onGround.reload.started += ctx => PlayerWeaponController.instance.Reload();
        onGround.SelectWeapon.started += ctx => PlayerWeaponController.instance.SelectNextSlot();
        onGround.TakeWeapon.started += ctx => PlayerWeaponController.instance.TakeWeapon();


    }

    private void FixedUpdate()
    {
        playerControll.ProcessMove(onGround.Movement.ReadValue<Vector2>() );


    }

    private void LateUpdate()
    {
        look.ProcessLook(onGround.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onGround.Enable();
    }

    private void OnDisable()
    {
        onGround.Disable();
    }

}
