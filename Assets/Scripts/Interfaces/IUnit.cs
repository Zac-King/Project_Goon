interface IUnit<T>
{
    FiniteStateMachine<T> fsm
    {
        get;  
    }

    void SetupMachine();
    void onHit();
    void onAttack();
    void onDeath();
    void onStart();
    void onInit();

    float MaxHealth
    {
        get;
        set;
    }
    float Health
    { get; set; }
    float Attack
    { get; set; } 
    float Defense
    { get; set; }
    float Speed
    { get; set; }
    bool Alive
     { get; set; } 
}



//struct Effect
//{
//    UnitStat effectedStat;
//    int duration;
//    float modifer;
//}

//enum UnitStat
//{
//    HEALTH,
//    ATTACK,
//    DEFENCE,
//    SPEED
//}
