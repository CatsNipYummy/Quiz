using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text questionTextField;
	public Text scoreTextField;
	public Button[] optionButtons;
	public GameObject scoreManager;

	public int scoreIncrementer;

	private QuestionAndOptions questionAndOptions;
	private bool m_bEnableInput = true; // Disable button presses after submission

	// Use this for initialization
	void Start () {
		setQuestionAndOptions();

		setUI();

		// Instantiate Score Manager
		if (ScoreManager.instance == null)
			Instantiate(scoreManager);
	}

	// Set question and answers
	void setQuestionAndOptions() {
		questionAndOptions = new QuestionAndOptions();
		questionAndOptions.setQuestion("Which year was CMU founded?");
		
		questionAndOptions.setOptions("1850",
		                              "1875",
		                              "1900",
		                              "1925");
		// Set right answer
		questionAndOptions.setRightOption(3);
	}

	// Set values into the UI
	void setUI () {
		// Set Score
		scoreTextField.text = "Score: " + ScoreManager.score();

		// Set Question Text
		questionTextField.text = questionAndOptions.question();

		// Set answer values to the options
		for (int i = 0; i < questionAndOptions.optionsCount(); i++) {
			Button gameObj = optionButtons[i];
			Text buttonText = gameObj.GetComponentInChildren<Text>();
			buttonText.text = questionAndOptions.optionAtIndex(i).ToString();
		}
	}

	public void optionSelected (Button button) {
		// Set selected option to yellow (awaiting response)
		if (m_bEnableInput) {
			button.image.color = Color.yellow;

			// Find the selected button
			string option = button.name.Split(' ')[1];
			StartCoroutine(checkAnswer(option, button, 2.0f));

			m_bEnableInput = false;
		}
	}

	IEnumerator checkAnswer (string option, Button selectedButton, float delayTime) {
		yield return new WaitForSeconds(delayTime);

		bool rightAnswer = true;

		for (int i = 0; i < questionAndOptions.optionsCount(); i++) {
			Button eachButton = optionButtons[i] as Button;

			if (i + 1 == questionAndOptions.rightOption()) {
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
			scoreTextField.text = "Score: " + ScoreManager.incrementScoreBy(scoreIncrementer);
		}

		yield return new WaitForSeconds(delayTime);
		// enable button presses
		m_bEnableInput = true;
		// reload the scene with the same question
		Application.LoadLevel(Application.loadedLevel);
	}
}
