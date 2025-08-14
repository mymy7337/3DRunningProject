using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{


    private Player player;
    public Player Player
    {
        get { return player; }
        set { player = value; }
    }

    protected override bool isDestroy => true;

    protected override void Awake()
    {
        base.Awake();
    }
}
