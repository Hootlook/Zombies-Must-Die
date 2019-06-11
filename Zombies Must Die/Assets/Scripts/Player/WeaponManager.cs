using BeardedManStudios.Forge.Networking;
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

        Debug.DrawRay(transform.position + Vector3.up * .5f, Camera.main.transform.forward, Color.cyan);

        if (networkObject.IsOwner)
        {
            if (i.isUsing)
            {
                if (Physics.Raycast(transform.position + Vector3.up * .5f, Camera.main.transform.forward, out RaycastHit hit, 2))
                {
                    if (hit.collider.GetComponentInParent<IEntityBase>() != null)
                    {
                        hit.collider.GetComponentInParent<IEntityBase>().OnInteract((int)ps.playerID);
                    }
                }
            }
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

    public override void PlayerId(RpcArgs args)
    {
        throw new NotImplementedException();
    }
}
