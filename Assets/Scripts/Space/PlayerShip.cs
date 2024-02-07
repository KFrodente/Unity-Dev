using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShip : Interactable
{
    [SerializeField] private Action action;
    [SerializeField] private Inventory inventory;

    public float health;

    private void Start()
    {
        if (action != null)
        {
            action.onEnter += OnInteractStart;
            action.onStay += OnInteractActive;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inventory.Use();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            inventory.OnStopUse();
        }
    }
    public override void OnInteractActive(GameObject gameObject)
    {
        //
    }

    public override void OnInteractEnd(GameObject gameObject)
    {
        //
    }

    public override void OnInteractStart(GameObject gameObject)
    {
        //
    }

}
