using UnityEngine;
using System.Collections;

public abstract class Resettable : MonoBehaviour
{
	void Start ()
	{
		Reset();
		ServiceProvider.GetService<Game>().RegisterResettable(this);
	}

	abstract public void Reset();
}
