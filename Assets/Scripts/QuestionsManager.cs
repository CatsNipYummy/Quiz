using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionsManager : MonoBehaviour {

	public Text questionTextField;
	public Text score;
	public Button[] options;
	public GameObject scoreManager;

	public QuestionAndAnswers questionAndAnswers;

	private bool m_bEnableInput = true; // Disable button presses after submission

	// Use this for initialization
	void Start () {
		setQuestionAndAnswers();

		setUI();

		// Instantiate Score Manager
		if (ScoreManager.instance == null)
			Instantiate(scoreManager);
	}

	// Set question and answers
	void setQuestionAndAnswers() {
		questionAndAnswers = new QuestionAndAnswers();
		questionAndAnswers.setQuestion("Which year was CMU founded?");
		
		questionAndAnswers.setAnswers("1850",
		                              "1875",
		                              "1900",
		                              "1925");
		// Set right answer
		questionAndAnswers.setRightAnswer(3);
	}

	// Set values into the UI
	void setUI () {
		// Set Score
		score.text = "Score: " + ScoreManager.score();

		// Set Question Text
		questionTextField.text = questionAndAnswers.question();

		// Set answer values to the options
		for (int i = 0; i < questionAndAnswers.answersCount(); i++) {
			Button gameObj = options[i];
			Text buttonText = gameObj.GetComponentInChildren<Text>();
			buttonText.text = questionAndAnswers.answerAtIndex(i).ToString();
		}
	}

	public void optionSelected (Button button) {
		// Set selected option to yellow (awaiting response)
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

		for (int i = 0; i < questionAndAnswers.answersCount(); i++) {
			Button eachButton = options[i] as Button;

			if (i + 1 == questionAndAnswers.rightAnswer()) {
				// Set correct answer to green (not caring about the player's option)
				eachButton.image.color = Color.green;

				// Right Player Option Check
				if ((i + 1) != int.Parse(option)) {
					// Incorrect Answer
					rightAnswer = false;
					selectedButton.image.color = Color.red;
					break;
				}
			}
		}

		// Check if answer is correct
		if (rightAnswer) {
			score.text = "Score: " + ScoreManager.incrementScoreBy(10);
		}

		yield return new WaitForSeconds(delayTime);
		// enable button presses
		m_bEnableInput = true;
		// reload the scene with the same question
		Application.LoadLevel(Application.loadedLevel);
	}
}
