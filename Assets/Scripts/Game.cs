using UnityEngine;
using System.Collections;

public class Game : Service
{
	public void Score(Player _PlayerGoal)
	{
		Debug.Log("Score for " + _PlayerGoal);
	}
}
