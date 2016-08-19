using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance = null;
	private static int m_iScore = 0;
	
	void Awake ()
	{
		if (instance == null)			
			instance = this;
		else if (instance != this)			
			Destroy(gameObject);    		
	}

	public static int incrementScoreBy (int increment) {
		return m_iScore += increment;
	}

	public static int score () {
		return m_iScore;
	}
}
