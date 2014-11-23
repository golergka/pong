using UnityEngine;
using System.Collections;

public class Ball : Resettable
{

	public Vector3 StartVelocity;

	Vector3 m_Velocity = new Vector3();

	public override void Reset()
	{
		m_Velocity = StartVelocity;
	}

	public void OnCollisionEnter(Collision _Collision)
	{
		var wall = _Collision.gameObject.GetComponent<Wall>();
		if (wall == null)
		{
			return;
		}
		var normal = wall.Normal.normalized;
		m_Velocity = m_Velocity - 2 * Vector3.Dot(m_Velocity, normal) * normal;
	}

	public void FixedUpdate()
	{
		transform.position += m_Velocity * Time.fixedDeltaTime;
	}

	public void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Vector3 vel = Application.isPlaying ? m_Velocity : StartVelocity;
		Gizmos.DrawLine(transform.position, transform.position + vel);
	}
}
