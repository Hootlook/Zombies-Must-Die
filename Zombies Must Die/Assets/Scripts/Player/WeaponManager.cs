using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : PlayerBehavior
{
	public int selectedWeapon = 0;
	public Transform weaponBone;
	GameObject grip;
    PlayerSetup ps;
	Animator a;
	public Vector3 handOffset;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        a = GetComponent<Animator>();
        ps = GetComponent<PlayerSetup>();
		SelectWeapon(selectedWeapon);
	}

	void Update()
	{
        if (networkObject == null) return;

        if (networkObject.IsOwner)
        {
            int previousSelectedWeapon = selectedWeapon;

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon >= weaponBone.childCount - 1) selectedWeapon = 0;
                else selectedWeapon++;
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
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

        a.SetInteger("selectedWeapon", selectedWeapon);
    }

	void SelectWeapon(int selectedWeapon)
	{
		int i = 0;
		foreach (Transform weapon in weaponBone)
		{
			if (i == selectedWeapon)
			{
				weapon.gameObject.SetActive(true);
				grip = weapon.Find("Rig/Main/Grip").gameObject;
			}
			else weapon.gameObject.SetActive(false);
			i++;
		}
	}
    /*
	private void OnAnimatorIK(int layerIndex)
	{
		Vector3 target = grip.transform.position + grip.transform.TransformDirection(handOffset);
		layerIndex = a.GetLayerIndex("Upper Body");
		a.SetIKPosition(AvatarIKGoal.LeftHand, target);
		a.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

	}*/
}
