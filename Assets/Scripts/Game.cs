using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Game : Service
{
	#region Keeping score

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
		if (!CheckWin())
		{
			ResetRound();
		}
	}

	void ResetScore()
	{
		RedScore = 0;
		BlueScore = 0;
	}

	void UpdateScoreText()
	{
		if (Text != null)
		{
			Text.text = "Red: " + m_RedScore + " Blue: " + m_BlueScore;
		}
	}

	#endregion

	#region Winning

	bool CheckWin()
	{
		if (m_RedScore >= MaxScore || m_BlueScore >= MaxScore)
		{
			StartCoroutine(WinCoroutine());
			return true;
		}
		return false;
	}

	IEnumerator WinCoroutine()
	{
		Pause();
		yield return new WaitForSeconds(2f);
		Unpause();
		ResetGame();
	}

	#endregion

	#region Resetting round

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

	#endregion

	#region Pausing gameplay

	List<Behaviour> m_Pausables = new List<Behaviour>();

	void SetPause(bool _Value)
	{
		foreach(var c in m_Pausables)
		{
			if (c != null)
			{
				c.enabled = !_Value;
			}
		}
	}

	int m_PauseCounter = 0;

	public void Pause()
	{
		if (m_PauseCounter == 0)
		{
			SetPause(true);
		}
		m_PauseCounter++;
	}

	public void Unpause()
	{
		m_PauseCounter--;
		if (m_PauseCounter == 0)
		{
			SetPause(false);
		}
	}

	public void RegisterPausable(Behaviour _Pausable)
	{
		m_Pausables.Add(_Pausable);
	}

	#endregion

	public Ball MainBall
	{
		get
		{
			return GameObject.FindWithTag("MainBall").GetComponent<Ball>();
		}
	}

	public void ResetGame()
	{
		ResetRound();
		ResetScore();
	}

}
