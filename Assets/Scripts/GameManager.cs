using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SearchService;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;
using System;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private float maxTime;

    public GameObject[] pigeons;

    [SerializeField] private GameObject titleUI;

    [SerializeField] private TMP_Text collectionUI;

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TMP_Text pigeonsCollectedUI;
    [SerializeField] private TMP_Text timeTakenUI;
    [SerializeField] private TMP_Text gradeUI;

    [SerializeField] private TMP_Text timerUI;

    [SerializeField] private FloatVariable health;

    [SerializeField] private GameObject respawn;
    [Header("Events")]
    //[SerializeField] private IntEvent scoreEvent;
    [SerializeField] private VoidEvent gameStartEvent;
    [SerializeField] private GameObjectEvent respawnEvent;

    public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER
    }

    public State state = State.TITLE;
    public float timer = 0;

    public float Timer
    {
        get { return timer; }
        set { timer = value; timerUI.text = string.Format("{0:F2}", timer); }
    }

    private void OnEnable()
    {
        //scoreEvent.Subscribe(OnAddPoints);
    }

    private void OnDisable()
    {
        //scoreEvent.UnSubscribe(OnAddPoints);
    }

    void Update()
    {
		switch (state)
		{
			case State.TITLE:
                gameOverUI.SetActive(false);
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
				break;
			case State.START_GAME:
                StartGame();
				break;
			case State.PLAY_GAME:
                Time.timeScale = 1;
                Timer += Time.deltaTime;
                collectionUI.text = "pigeons collected: " + Goal.Instance.pigeonsCollected + " / " + pigeons.Length;


                if (Timer > maxTime || Goal.Instance.pigeonsCollected == pigeons.Length) state = State.GAME_OVER;
				break;
			case State.GAME_OVER:
                gameOverUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                pigeonsCollectedUI.text = "Pigeons collected: " + Goal.Instance.pigeonsCollected.ToString() + " / " + pigeons.Length;
                timeTakenUI.text = "Time taken: " + string.Format("{0:F2}", Timer);

                float maxScore = (pigeons.Length * 1000) * (Timer / (maxTime + 5));
                float secretScore = (Goal.Instance.pigeonsCollected * 1000) * (Timer / (maxTime + 5));
                Debug.Log(secretScore);

                if (Goal.Instance.pigeonsCollected >= pigeons.Length) gradeUI.text = "Grade: S++";
                else if (secretScore > maxScore * .95f) gradeUI.text = "Grade: S+";
                else if (secretScore > maxScore * .9f) gradeUI.text = "Grade: S";
                else if (secretScore > maxScore * .85f) gradeUI.text = "Grade: A++";
                else if (secretScore > maxScore * .8f) gradeUI.text = "Grade: A+";
                else if (secretScore > maxScore * .75f) gradeUI.text = "Grade: A";
                else if (secretScore > maxScore * .7f) gradeUI.text = "Grade: B+";
                else if (secretScore > maxScore * .65f) gradeUI.text = "Grade: B";
                else if (secretScore > maxScore * .6f) gradeUI.text = "Grade: C";
                else if (secretScore > maxScore * .5f) gradeUI.text = "Grade: D";
                else if (secretScore > maxScore * .3f) gradeUI.text = "Grade: F";
                else gradeUI.text = "Grade: :/";


				break;
		}

	}
    public void OnPlayerDead()
    {
        state = State.TITLE;
    }

    public void OnAddPoints(int points)
    {
        print(points);
    }

    public void OnTimeRemoveEvent(float time)
    {
        Timer -= time;
        if (Timer <= 0) Timer = 0;
    }


    public void RestartGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        foreach (GameObject pigeon in pigeons)
        {
            pigeon.GetComponent<FollowPlayer>().setState(FollowPlayer.State.SPAWN);
        }
        titleUI.SetActive(false);
        gameOverUI.SetActive(false);
        respawnEvent.RaiseEvent(respawn);
        health.value = 100;
        Goal.Instance.pigeonsCollected = 0;
        Timer = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        state = State.PLAY_GAME;
    }
}
