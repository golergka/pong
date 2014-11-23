using UnityEngine;
using System.Collections;

public class DestroyOnReset : Resettable
{
	public override void Reset()
	{
		if (this != null)
		{
			Object.Destroy(gameObject);
		}
	}
}
