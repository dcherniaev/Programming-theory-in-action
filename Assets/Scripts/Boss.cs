using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField]
    private float strength = 7f;


    public override void PrintMessage()
    {
        string enemyName = this.gameObject.name;
        Debug.Log("BOSS spawned");
    }

}

