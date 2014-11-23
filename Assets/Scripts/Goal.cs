using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
	Game m_Game;
	Game Game
	{
		get
		{
			if (m_Game == null)
			{
				m_Game = ServiceProvider.GetService<Game>();
			}
			return m_Game;
		}
	}
	
	public Player Player;

	public void OnTriggerEnter(Collider _Other)
	{
		Game.Score(Player);
	}
}
