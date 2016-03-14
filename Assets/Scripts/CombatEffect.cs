using UnityEngine;
using System.Collections;


namespace Combat
{
    public enum UnitStat
    {
        HEALTH,
        ATTACK,
        DEFENCE,
        SPEED
    }

    public class CombatEffect
    {
        private string Name;
        UnitStat TargetedStat;
        private int Duration;
        private float Modifer;

        public CombatEffect(string name, UnitStat targetedStat, int duration )
        {
            Name            = name;
            TargetedStat    = targetedStat;
            Duration        = duration;
        }

        
    }
}
