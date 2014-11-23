using UnityEngine;
using System.Collections;

public class AIBallDestroyer : MonoBehaviour
{
	private void OnTriggerEnter(Collider _Other)
	{
		var ball = _Other.gameObject.GetComponent<Ball>();
		if (ball == null || ball.gameObject.tag != AI.AIBallTag)
		{
			return;
		}
		ball.Speed = 0f;
	}
}
