using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

	public Vector3 StartVelocity;

	Vector3 m_Velocity = new Vector3();

	public void Awake()
	{
		m_Velocity = StartVelocity;
	}

	public void OnCollisionEnter(Collision _Collision)
	{
		Debug.Log("Collision!");
		m_Velocity.x = - m_Velocity.x;
		m_Velocity.y = - m_Velocity.y;
		m_Velocity.z = - m_Velocity.z;
	}

	public void FixedUpdate()
	{
		transform.position += m_Velocity * Time.deltaTime;
	}

}
