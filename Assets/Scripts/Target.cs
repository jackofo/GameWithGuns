
using System.Linq;

using UnityEngine;

public class Target : MonoBehaviour
{
	public enum Type { Small, Big }
	public Type targetType;

	public void GetHit(params Type[] hitType)
	{
		if(hitType.Contains(targetType))
		{
			Destroy(gameObject,0.1f);

		}
	}
}