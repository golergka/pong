using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
	public void OnTriggerEnter(Collider _Other)
	{
		Debug.Log("Goal!");
	}
}
