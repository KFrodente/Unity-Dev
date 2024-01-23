using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private FloatVariable health;
    [SerializeField] private PlayerController characterController;

    [Header("Events")]
    [SerializeField] private IntEvent scoreEvent = default;
    [SerializeField] private VoidEvent gameStartEvent = default;
    [SerializeField] private VoidEvent playerDeadEvent = default;

    private int score = 0;

    public int Score { 
        get { return score; } 
        set 
        { 
            score = value; 
            scoreText.text = "Score: " + score;
            scoreEvent.RaiseEvent(score);
        } 
    }

    private void OnEnable()
    {
        gameStartEvent.Subscribe(OnStartGame);
    }

    public void OnStartGame()
    {
        characterController.enabled = true;
    }

    public void AddPoints(int points)
    {
        Score += points;
    }

    public void TakeDamage(float damage)
    {
        health.value -= damage;
        if (health.value <= 0)
        {
            playerDeadEvent.RaiseEvent();
        }
    }

    public void OnRespawn(GameObject respawn)
    {
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;
        GetComponent<PlayerController>().Reset();
    }

    public void LaunchPlayer(float launchForce)
    {
        characterController.rb.velocity = Vector3.zero;
        characterController.rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
    }
}
