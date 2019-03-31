﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	public int selectedWeapon = 0;
	[SerializeField]
	Transform weaponBone;
	GameObject grip;
	Animator a;
	public Vector3 handOffset;

	void Start()
	{
		a = GetComponent<Animator>();
		SelectWeapon();
	}

	void Update()
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
			SelectWeapon();
		}

	}

	void SelectWeapon()
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
		Vector3 target = grip.transform.position + handOffset;
		layerIndex = a.GetLayerIndex("Upper Body");
		a.SetIKPosition(AvatarIKGoal.LeftHand, target);
		a.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

	}*/
}
