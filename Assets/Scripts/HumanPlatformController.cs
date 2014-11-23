using UnityEngine;
using System.Collections;

public class HumanPlatformController : PlatformController
{
	public override float Direction
	{
		get
		{
			return Input.GetAxis("Vertical");
		}
	}
}
