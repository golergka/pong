using UnityEngine;
using System.Collections;

public class AIPlatformController : PlatformController
{
	public override float Direction
	{
		get
		{
			var ai = ServiceProvider.GetService<AI>();
			var ball = ai.AIBall != null ? 
				ai.AIBall : 
				ServiceProvider.GetService<Game>().MainBall;
			if (ball == null)
			{
				return 0f;
			}
			var delta = ball.transform.position.z - transform.position.z;
			Debug.DrawLine(transform.position, transform.position + new Vector3(0,0,delta), Color.white, 0.0f, false);
			var multiplier = Mathf.Abs(delta) < ai.MinimumDelta ?
				Mathf.Abs(delta) / ai.MinimumDelta :
				1f;
			return multiplier * Mathf.Sign(delta);
		}
	}
}
