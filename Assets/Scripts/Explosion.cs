using UnityEngine;

public class Explosion : MonoBehaviour
{
	void Update()
	{
		Destroy(gameObject, 0.5f);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out Target target))
		{
			target.GetHit(Target.Type.Small, Target.Type.Big);
		}
	}
}
