using UnityEngine;
using System.Collections;

public class QuestionAndAnswers {

	private string m_sQuestion;
	private ArrayList m_alAnswers;

	private int m_iRightAnswer;

	public QuestionAndAnswers() {
		m_sQuestion = "";
		m_alAnswers = new ArrayList(4);
	}

	~QuestionAndAnswers() {
		m_sQuestion = null;
		m_alAnswers.Clear();
	}

	// public methods
	// Set Question
	public void setQuestion (string question) {
		m_sQuestion = question;
	}

	// Set Answers
	public void setAnswers(string answer1,
	                       string answer2,
	                       string answer3,
	                       string answer4) {
		m_alAnswers.Add(answer1);
		m_alAnswers.Add(answer2);
		m_alAnswers.Add(answer3);
		m_alAnswers.Add(answer4);
	}

	// Set Right Answer
	public void setRightAnswer (int rightAnswer) {
		m_iRightAnswer = rightAnswer;
	}

	// Get Question
	public string question () {
		return m_sQuestion;
	}

	// Get Answers
	public ArrayList answers () {
		return m_alAnswers;
	}

	// Get Right Answer
	public int rightAnswer () {
		return m_iRightAnswer;
	}

	// Get Answers Count
	public int answersCount () {
		return m_alAnswers.Count;
	}

	// Get Answer At Index
	public string answerAtIndex (int index) {
		return m_alAnswers[index].ToString();
	}

}
