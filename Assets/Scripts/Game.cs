using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game : Service
{
	public Text Text;
	public int MaxScore = 10;

	int m_RedScore;
	int m_BlueScore;

	int RedScore
	{
		get { return m_RedScore; }
		set
		{
			m_RedScore = value;
			UpdateScoreText();
		}
	}

	int BlueScore
	{
		get { return m_BlueScore; }
		set
		{
			m_BlueScore = value;
			UpdateScoreText();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		ResetScore();
	}

	public bool IsHuman(Player _Player)
	{
		return _Player == Player.Blue;
	}

	public Ball MainBall
	{
		get
		{
			return GameObject.FindWithTag("MainBall").GetComponent<Ball>();
		}
	}

	public void Score(Player _PlayerGoal)
	{
		switch(_PlayerGoal)
		{
			case (Player.Red):
				RedScore++;
				break;

			case (Player.Blue):
				BlueScore++;
				break;
		}
		CheckWin();
		ResetRound();
	}

	void ResetScore()
	{
		RedScore = 0;
		BlueScore = 0;
	}

	void CheckWin()
	{
		if (m_RedScore > MaxScore || m_BlueScore > MaxScore)
		{
			ResetScore();
		}
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
