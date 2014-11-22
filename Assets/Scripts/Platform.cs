using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
	public float Speed;

	public void FixedUpdate()
	{
		var speed = Input.GetAxis("Vertical") * Speed;
		var position = transform.position;
		position.z += speed * Time.fixedDeltaTime;
		transform.position = position;
	}
}
