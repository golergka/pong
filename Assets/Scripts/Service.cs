using UnityEngine;
using System.Collections;

public class Service : MonoBehaviour
{
	protected virtual void Awake()
	{
		ServiceProvider.Register(this);
	}
}
