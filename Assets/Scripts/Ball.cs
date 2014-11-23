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

	bool DrawDebug
	{
		get
		{
			return gameObject.tag == "MainBall";
		}
	}

	void Awake()
	{
		r_StartVelocity = Velocity;
		ServiceProvider.GetService<Game>().RegisterPausable(this);
	}

	public override void Reset()
	{
		Velocity = r_StartVelocity;
	}

	void DrawDebugLine(Vector3 _Delta, Color _Color)
	{
		if (DrawDebug)
		{
			Debug.DrawLine(
					transform.position, 
					transform.position + _Delta.normalized * 5f,
					_Color,
					2f,
					false
				);
		}
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
		var newVelocity = Velocity - 2 * Vector3.Dot(Velocity, normal) * normal;
		DrawDebugLine(Velocity, Color.yellow);
		DrawDebugLine(normal, Color.blue);
		DrawDebugLine(newVelocity, Color.green);
		Velocity = newVelocity;
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
