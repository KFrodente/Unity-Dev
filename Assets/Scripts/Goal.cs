using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Singleton<Goal>
{
    public int pigeonsCollected;

    public void onCollectPigeon()
    {
        pigeonsCollected++;
        Debug.Log(pigeonsCollected);
    }
}
