using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : Service
{
	public void Score(Player _PlayerGoal)
	{
		Debug.Log("Score for " + _PlayerGoal);
	}

	List<Resettable> m_Resettables = new List<Resettable>();

	public void RegisterResettable(Resettable _ToRegister)
	{
		m_Resettables.Add(_ToRegister);
	}

	void Reset()
	{
		foreach(var r in m_Resettables)
		{
			r.Reset();
		}
	}
}
