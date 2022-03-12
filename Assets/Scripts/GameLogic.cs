using System.Collections.Generic;
using System.Linq;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
	public TMP_Text winScreen;
	public TMP_Text resetTimer;
	public TMP_Text scoreText;
	public List<Target> targets;

	public int pointsToWin = 5;
	public int score = 0;
	public float Timer => timer;
	private float timer = 5f;

	void Update()
	{
		if (targets.Count(t => t != null) != pointsToWin - score)
		{
			score++;
			scoreText.text = $"Score: {score}";
			if (score >= pointsToWin)
			{
				winScreen.gameObject.SetActive(true);
				resetTimer.gameObject.SetActive(true);
			}
		}

		if (score >= pointsToWin)
		{
			resetTimer.text = $"Time until restart: {Mathf.RoundToInt(timer)}";
			timer -= Time.deltaTime;
			if (timer <= 0f)
			{
				SceneManager.LoadScene(0);
			}
		}
	}
}
