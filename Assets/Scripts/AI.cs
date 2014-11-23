using UnityEngine;
using System.Collections;

public class AI : Service
{
	Ball m_AIBall;
	public Ball AIBall
	{
		get { return m_AIBall; }
		set
		{
			if (m_AIBall != null)
			{
				Object.Destroy(m_AIBall.gameObject);
			}
			m_AIBall = value;
		}
	}
	public float PredictionMultiplier = 1.5f;
	public float MinimumDelta = 0.2f;

	public const string AIBallTag = "AIBall";
}
