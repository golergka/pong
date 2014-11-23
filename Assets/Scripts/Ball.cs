using UnityEngine;
using System.Collections;

public class Ball : Resettable
{
	Vector3 r_StartVelocity;

	public Vector3 Velocity = new Vector3();
	public float Speed
	{
		get { return Velocity.magnitude; }
		set
		{
			Velocity = Velocity.normalized * value;
		}
	}

	void Awake()
	{
		r_StartVelocity = Velocity;
	}

	public override void Reset()
	{
		Velocity = r_StartVelocity;
	}

	public void OnCollisionEnter(Collision _Collision)
	{
		var wall = _Collision.gameObject.GetComponent<Wall>();
		if (wall == null)
		{
			return;
		}
		var normal = wall.WorldNormal.normalized;
		if (Vector3.Angle(Velocity, normal) < 90f)
		{
			return;
		}
		Debug.DrawLine(transform.position, transform.position + Velocity.normalized, Color.yellow, 2f, false);
		Velocity = Velocity - 2 * Vector3.Dot(Velocity, normal) * normal;
		Debug.DrawLine(transform.position, transform.position + normal, Color.blue, 2f, false);
		Debug.DrawLine(transform.position, transform.position + Velocity.normalized, Color.green, 2f, false);
	}

	public void FixedUpdate()
	{
		transform.position += Velocity * Time.fixedDeltaTime;
	}

	public void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + Velocity);
	}
}
