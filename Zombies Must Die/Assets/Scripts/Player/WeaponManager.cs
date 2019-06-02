using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : PlayerBehavior
{
	public int selectedWeapon = 0;
    public int weaponId;
	public Transform weaponBone;
    public WeaponBase currentWeapon;
    PlayerSetup ps;
    Inputs i;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        ps = GetComponent<PlayerSetup>();
        i = GetComponent<Inputs>();
		SelectWeapon(selectedWeapon);
	}

	void Update()
    {
        if (networkObject == null) return;

        if (networkObject.IsOwner)
        {
            int previousSelectedWeapon = selectedWeapon;

            if (i.mouseWheel > 0f)
            {
                if (selectedWeapon >= weaponBone.childCount - 1) selectedWeapon = 0;
                else selectedWeapon++;
            }

            if (i.mouseWheel < 0f)
            {
                if (selectedWeapon <= 0) selectedWeapon = weaponBone.childCount - 1;
                else selectedWeapon--;
            }

            if (previousSelectedWeapon != selectedWeapon)
            {
                SelectWeapon(selectedWeapon);
            }
        }
        else
        {
            selectedWeapon = ps.selectedWeapon;
            SelectWeapon(ps.selectedWeapon);
        }

        //CheckForChanges();

        //JUST FOR DEBUGGING

        if (Input.GetKeyDown(KeyCode.G))
        {
            WeaponBehavior g = NetworkManager.Instance.InstantiateWeapon(index: 1, position: weaponBone.position, rotation: weaponBone.rotation);
            g.transform.SetParent(weaponBone);
        }

    }

    private void CheckForChanges()
    {
        int actifWeapons = 0;
        foreach (Transform weapon in weaponBone)
        {
            if (weapon.gameObject.activeInHierarchy == true) actifWeapons++;
        }
        if (actifWeapons == 0)
        {
            SelectWeapon(0);
        }
    }

    public void SelectWeapon(int selectedWeapon)
	{
		int i = 0;
		foreach (Transform weapon in weaponBone)
		{
			if (i == selectedWeapon)
			{
				weapon.gameObject.SetActive(true);
                currentWeapon = weapon.GetComponent<WeaponBase>();
                weaponId = currentWeapon.id;
            }
			else weapon.gameObject.SetActive(false);
			i++;
		}
	}
}
