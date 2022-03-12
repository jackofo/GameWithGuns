using UnityEngine;

public class Portal : MonoBehaviour
{
	public Transform link;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.transform.position = link.position + link.forward;
			float rotation = -Quaternion.Angle(transform.rotation, link.rotation);
			rotation += 180;
			other.transform.Rotate(Vector3.up, rotation);
		}
	}
}
