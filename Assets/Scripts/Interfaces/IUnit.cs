using System.Collections;

interface IUnit<T>
{
    void SetupMachine();
    void onHit(int damage);
    void onAttack();
    void onDeath();
    void onStart();
    void onInit();
    void onSelection();

    FiniteStateMachine<T> fsm
    { get; }

    // Unit Stats
    int MaxHealth
    { get; set; }
    int Health
    { get; set; }
    int Attack
    { get; set; }
    int Defense
    { get; set; }
    int Speed
    { get; set; }
    bool Alive
    { get; set; } 
}
