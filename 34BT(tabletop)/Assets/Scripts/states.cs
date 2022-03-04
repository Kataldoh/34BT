public enum GameState
{
    idle,
    play,
    dead,
    pause,
    save,
    load

}


public enum PlayerState
{
    idle,
    groundMoving,
    dash,
    damage,
    dead,
    jump,
    defence,
    sprinting,
}


public enum EnemyState
{
    idle,
    attack,
    patrol,
    defence,
    dead
}

public enum BossState
{
    idle,
    attack,
    jump,
    bump,
    dead
}



public enum LevelState
{
    play,
    dead,
    pause,
}