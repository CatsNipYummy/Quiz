using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance = null;
	private static int m_iScore = 0;

	// Use this for initialization
	void Start () {
	
	}

	
	//Awake is always called before any Start functions
	void Awake ()
	{
		if (instance == null)			
			instance = this;
		else if (instance != this)			
			Destroy(gameObject);    
		
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static int incrementScoreBy (int increment) {
		return m_iScore += increment;
	}

	public static int score () {
		return m_iScore;
	}
}
