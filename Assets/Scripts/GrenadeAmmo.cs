using UnityEngine;

public class GrenadeAmmo : MonoBehaviour
{
	public Transform explosionEffect;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Terrain"))
		{
			Debug.Log("Greande!");
			var explosion = Instantiate(explosionEffect);
			explosion.position = transform.position;
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("shake");

			Destroy(gameObject,0.1f);
		}
	}
}
