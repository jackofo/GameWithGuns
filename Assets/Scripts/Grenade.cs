using UnityEngine;

namespace Assets
{
	public class Grenade : Weapon
	{
		public int ammo = 3;
		public float throwStrength = 16f;
		public Transform ammoPrefab;

		public override void Shoot(Camera cam)
		{
			if (ammo > 0)
			{
				var thrown = Instantiate(ammoPrefab);
				thrown.position = cam.transform.position;
				thrown.GetComponent<Rigidbody>().AddForce(cam.transform.forward * throwStrength, ForceMode.Impulse);
				ammo--;
			}
		}
	}
}