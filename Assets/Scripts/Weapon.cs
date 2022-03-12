using System;

using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
	public GameObject flash;
	public Transform flashPoint;
	public Sprite crosshair;
	public UnityEvent AltAction;
	public float cooldown = 0f;
	protected Camera cam;
	private AudioSource audio;
	private float timer = 0f;

	private void Awake()
	{
		audio = GetComponent<AudioSource>();
		cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}

	private void Update()
	{
		timer += Time.deltaTime;

		if (Input.GetMouseButton(0))
		{
			if (timer >= cooldown)
			{
				Shoot(cam);
				timer = 0f;
			}
		}

		if(Input.GetMouseButtonDown(1))
		{
			AltAction.Invoke();
		}
	}

	public virtual void Shoot(Camera cam)
	{
		if (audio != null)
		{
			audio.Play();
		}

		var flsh = Instantiate(flash, flashPoint);
		flsh.transform.position = flashPoint.position;
		Destroy(flsh, 1f);
	}

	public virtual void Clear()
	{

	}
}