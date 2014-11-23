using UnityEngine;
using System.Collections;

public class Field : Service
{
	public Bounds Bounds
	{
		get
		{
			return collider.bounds;
		}
	}
}
