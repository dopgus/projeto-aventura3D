using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public List<UIGunUpdater> uIGunUpdaters;

    public GunBase gunShootLimit;
    public GunBase gunShootAngle;
    public Transform gunPosition;

    private GunBase _currentGun;
    private GunBase gunShootLimitInstance;
    private GunBase gunShootAngleInstance;

    protected override void Init()
    {
        base.Init();

        CreateGun();

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();

        inputs.Gameplay.Weapon1.performed += ctx => SetWeaponActive(1);
        inputs.Gameplay.Weapon2.performed += ctx => SetWeaponActive(2);
    }

    private void CreateGun()
    {
        gunShootLimitInstance = Instantiate(gunShootLimit, gunPosition);
        gunShootLimitInstance.transform.localPosition = gunShootLimitInstance.transform.localEulerAngles = Vector3.zero;

        gunShootAngleInstance = Instantiate(gunShootAngle, gunPosition);
        gunShootAngleInstance.transform.localPosition = gunShootAngleInstance.transform.localEulerAngles = Vector3.zero;
        gunShootAngleInstance.gameObject.SetActive(false);

        _currentGun = gunShootLimitInstance;
    }

    private void SetWeaponActive(int weaponActiveNumber)
    {
        _currentGun.gameObject.SetActive(false);
        switch (weaponActiveNumber)
        {
            case 1:
                _currentGun = gunShootLimitInstance;
                break;
            case 2:
                _currentGun = gunShootAngleInstance;
                break;
            default:
                Debug.LogError("We don't have the given weapon number: " + weaponActiveNumber);
                break;
        }
        _currentGun.gameObject.SetActive(true);
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
        Debug.Log("Start Shoot");
    }

    private void CancelShoot()
    {
        Debug.Log("Cancel Shoot");
        _currentGun.StopShoot();
    }
}
