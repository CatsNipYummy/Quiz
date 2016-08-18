using UnityEngine;
using System.Collections;

public class QuestionAndOptions {

	private string m_sQuestion;
	private ArrayList m_alOptions;

	private int m_iRightOption;

	public QuestionAndOptions() {
		m_sQuestion = "";
		m_alOptions = new ArrayList(4);
	}

	~QuestionAndOptions() {
		m_sQuestion = null;
		m_alOptions.Clear();
	}

	// public methods

	// Set Question
	public void setQuestion (string question) {
		m_sQuestion = question;
	}

	// Set Options
	public void setOptions(string option1,
	                       string option2,
	                       string option3,
	                       string option4) {
		m_alOptions.Add(option1);
		m_alOptions.Add(option2);
		m_alOptions.Add(option3);
		m_alOptions.Add(option4);
	}

	// Set Right Option
	public void setRightOption (int rightOption) {
		m_iRightOption = rightOption;
	}

	// Get Question
	public string question () {
		return m_sQuestion;
	}

	// Get Options
	public ArrayList options () {
		return m_alOptions;
	}

	// Get Right Option
	public int rightOption () {
		return m_iRightOption;
	}

	// Get Options Count
	public int optionsCount () {
		return m_alOptions.Count;
	}

	// Get Option At Index
	public string optionAtIndex (int index) {
		return m_alOptions[index].ToString();
	}

}
