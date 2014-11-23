using UnityEngine;
using System.Collections;

public class ResettablePosition : Resettable
{
	Vector3 r_Position;

	void Awake()
	{
		r_Position = transform.position;
	}

	public override void Reset()
	{
		if (this != null)
		{
			transform.position = r_Position;
		}
	}
}
