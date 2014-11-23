using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game : Service
{
	public Text Text;

	int m_RedScore;
	int m_BlueScore;

	protected override void Awake()
	{
		base.Awake();
		m_RedScore = 0;
		m_BlueScore = 0;
		UpdateScoreText();
	}

	public void Score(Player _PlayerGoal)
	{
		switch(_PlayerGoal)
		{
			case (Player.Red):
				m_RedScore++;
				break;

			case (Player.Blue):
				m_BlueScore++;
				break;
		}
		UpdateScoreText();
		ResetRound();
	}

	void UpdateScoreText()
	{
		if (Text != null)
		{
			Text.text = "Red: " + m_RedScore + " Blue: " + m_BlueScore;
		}
	}

	List<Resettable> m_Resettables = new List<Resettable>();

	public void RegisterResettable(Resettable _ToRegister)
	{
		m_Resettables.Add(_ToRegister);
	}

	void ResetRound()
	{
		foreach(var r in m_Resettables)
		{
			r.Reset();
		}
	}
}
