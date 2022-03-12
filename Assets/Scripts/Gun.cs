using UnityEngine;

namespace Assets
{
	public class Gun : Weapon
	{
		public float precision = 1f;
		public Target.Type targetType;
		public GameObject bulletHole;
		private Animator animator;
		private bool aim = false;

		private void Start()
		{
			animator = GetComponent<Animator>();
		}

		public override void Shoot(Camera cam)
		{
			base.Shoot(cam);

			animator.SetTrigger("Pif");
			Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
			var off = !aim ? new Vector3(Random.Range(-precision, precision), Random.Range(-precision, precision), 0f) : Vector3.zero;
			ray.origin += off;
			ray.direction += off;
			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				Destroy(Instantiate(bulletHole, hit.point + Vector3.forward * 0.02f, Quaternion.LookRotation(hit.normal)), 10f);
				Debug.Log($"{hit.transform.name} has been shot!");
				if (hit.transform.TryGetComponent(out Target target))
				{
					target.GetHit(targetType);
				}
			}
		}

		public void Aim(bool reset = false)
		{
			if (reset)
			{
				aim = false;
			}
			else
			{
				aim = !aim;
			}

			animator.SetBool("Aim", aim);
			cam.GetComponent<Animator>().SetBool("zoom", aim);
		}

		public override void Clear()
		{
			Aim(true);
		}
	}
}