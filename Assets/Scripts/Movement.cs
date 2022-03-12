using System;

using UnityEngine;
using UnityEngine.Video;

public class Movement : MonoBehaviour
{
	[Header("References")]
	public Camera cam;

	[Header("Parameters")]
	public float movementSpeed = 0.1f;
	public float yRotationSpeed = 0.5f;
	public float xRotationSpeed = 2f;

	private float rotationX = 0f;
	private float rotationY = 0f;

	private Rigidbody rb;

	public VideoPlayer rick;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		//move
		rb.MovePosition(transform.position
			+ (Input.GetAxis("Vertical") * movementSpeed * transform.forward)
			+ (Input.GetAxis("Horizontal") * movementSpeed * transform.right));
		//looking up/down
		rotationX += Input.GetAxis("Mouse Y") * xRotationSpeed;
		rotationX = Mathf.Clamp(rotationX, -60f, 60f);
		cam.transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.left);
		//rotating left/right
		rotationY = Input.GetAxis("Mouse X") * yRotationSpeed;
		transform.Rotate(Vector3.up, rotationY);
		//if(Input.GetKeyDown(KeyCode.Space))
		//{
		//	rick.Play();
		//}
	}
}
