using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
	[Header("References")]
	public Image crosshair;
	[Header("Parameters")]
	private int weaponIndex = 0;
	private Weapon currentWeapon;
	public List<Weapon> weapons;
	void Start()
	{
		NextWeapon();
	}

	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Q))
		{
			weaponIndex++;
			if (weaponIndex >= weapons.Count)
			{
				weaponIndex = 0;
			}

			NextWeapon();
		}
	}

	private void NextWeapon()
	{
		if (weapons.Count > 0)
		{
			if (currentWeapon != null)
			{
				currentWeapon.Clear();
				currentWeapon.gameObject.SetActive(false);
			}

			currentWeapon = weapons[weaponIndex];
			currentWeapon.gameObject.SetActive(true);
			crosshair.sprite = currentWeapon.crosshair;
			Debug.Log($"Switched weapon to: {currentWeapon.name}");
		}
	}
}
