using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionsManager : MonoBehaviour {

	public Text question;
	public Text score;
	public Button[] options;
	public GameObject scoreManager;

	private ArrayList m_alStringList;
	private bool m_bEnableInput = true;
	private int m_iSelectedAnswer = 0;
	private int m_iRightAnswer = 3; // Hardcoded

	// Use this for initialization
	void Start () {

		score.text = "Score: " + ScoreManager.score();

		question.text = "Which year was CMU founded?";

		m_alStringList = new ArrayList(4);
		m_alStringList.Add("1850");
		m_alStringList.Add("1875");
		m_alStringList.Add("1900");
		m_alStringList.Add("1925");

		// Set values to the options
		for (int i = 0; i < m_alStringList.Count; i++) {
			Button gameObj = options[i];
			Text buttonText = gameObj.GetComponentInChildren<Text>();
			buttonText.text = m_alStringList[i].ToString();
		}

		// Instantiate Score Manager
		if (ScoreManager.instance == null)
			Instantiate(scoreManager);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void optionSelected (Button button) {
		if (m_bEnableInput) {
			button.image.color = Color.yellow;

			string option = button.name.Split(' ')[1];
			StartCoroutine(checkAnswer(option, button, 2.0f));

			m_bEnableInput = false;
		}
	}

	IEnumerator checkAnswer (string option, Button selectedButton, float delayTime) {
		yield return new WaitForSeconds(delayTime);

		bool rightAnswer = true;

		for (int i = 0; i < m_alStringList.Count; i++) {
			Button eachButton = options[i] as Button;

			if (i + 1 == m_iRightAnswer) {
				eachButton.image.color = Color.green;

				// Right Answer Check
				if ((i + 1) != int.Parse(option)) {
					rightAnswer = false;
					selectedButton.image.color = Color.red;
					break;
				}
			}
		}

		if (rightAnswer) {
			score.text = "Score: " + ScoreManager.incrementScoreBy(10);
		}

		m_bEnableInput = true;

		yield return new WaitForSeconds(delayTime);
		Application.LoadLevel(Application.loadedLevel);
	}
}
