using UnityEngine;
using System.Collections;

public class AIBallSpawner : MonoBehaviour
{
	private void OnTriggerExit(Collider _Other)
	{
		var ai = ServiceProvider.GetService<AI>();
		var ball = _Other.gameObject.GetComponent<Ball>();
		if (ball == null || ball.gameObject.tag == AI.AIBallTag)
		{
			return;
		}
		var newBall = Object.Instantiate(ball) as Ball;
		newBall.Speed *= ai.PredictionMultiplier;
		newBall.gameObject.name += "_Invisible";
		newBall.gameObject.tag = AI.AIBallTag;
		newBall.gameObject.AddComponent<DestroyOnReset>();
		foreach(var r in newBall.GetComponentsInChildren<Renderer>())
		{
			Object.Destroy(r);
		}
		ai.AIBall = newBall;
	}
}
