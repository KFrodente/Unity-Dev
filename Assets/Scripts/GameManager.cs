using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SearchService;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject titleUI;
    [SerializeField] private TMP_Text livesUI;
    [SerializeField] private TMP_Text timerUI;
    [SerializeField] private Slider healthUI;

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
    public int lives = 0;

    public int Lives 
    { 
        get { return lives; } 
        set { lives = value; livesUI.text = $"lives: {lives}"; } 
    }

    public float Timer
    {
        get { return timer; }
        set { timer = value; timerUI.text = string.Format("{0:F1}", timer); }
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
                
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
				break;
			case State.START_GAME:
                
                titleUI.SetActive(false);
                timer = 60;
                lives = 3;
                health.value = 100;
                state = State.PLAY_GAME;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                gameStartEvent.RaiseEvent();
                respawnEvent.RaiseEvent(respawn);
				break;
			case State.PLAY_GAME:
                Timer -= Time.deltaTime;
                if (Timer <= 0)
                {
                    state = State.GAME_OVER;
                }
				break;
			case State.GAME_OVER:
				break;
		}

        healthUI.value = health.value / 100.0f;
	}

    public void OnStartGame()
    {
        state = State.START_GAME;
    }

    public void OnPlayerDead()
    {
        state = State.TITLE;
    }

    public void OnAddPoints(int points)
    {
        print(points);
    }
}
