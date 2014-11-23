using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
	public Vector3 Normal;

	public Vector3 WorldNormal
	{
		get
		{
			return (transform.TransformPoint(Normal) - transform.position).normalized;
		}
	}

	public void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, transform.position + 2 * WorldNormal);
	}
}
