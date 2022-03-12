using UnityEngine;

public class PortalGun : Weapon
{
	public Target.Type targetType;
	public GameObject bulletHole;
	public GameObject portal1;
	public GameObject portal2;

	public override void Shoot(Camera cam)
	{
		base.Shoot(cam);

		Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		if (Physics.Raycast(ray, out RaycastHit hit))
		{
			if (hit.transform.CompareTag("Walls"))
			{
				portal1.SetActive(true);
				portal1.transform.SetPositionAndRotation(hit.point + Vector3.forward * 0.02f, Quaternion.LookRotation(hit.normal));
			}
		}
	}

	public void OpenSecondPortal()
	{
		Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		if (Physics.Raycast(ray, out RaycastHit hit))
		{
			if (hit.transform.CompareTag("Walls"))
			{
				portal2.SetActive(true);
				portal2.transform.SetPositionAndRotation(hit.point + Vector3.forward * 0.02f, Quaternion.LookRotation(hit.normal));
			}
		}

	}

	public override void Clear()
	{
	}
}
