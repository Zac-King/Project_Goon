using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Combat 
{
    public enum UnitState
    {
        INIT,
        START,
        SELECTION,
        TARGET,
        RESOLVE,
        END
    }

    /// <summary>
    /// Participates in combat
    /// contains stats for member
    /// </summary>
    public class Unit : MonoBehaviour, IUnit<UnitState>
    {
        //simulate some input,  Only for testing 
        public int mhp,  hp,  atk,  def,  spd;
        bool  alv;

        //this is the actual value
        private int _mhp, _hp, _atk, _def, _spd;
        bool _alv;

        Animator anim;

        private FiniteStateMachine<UnitState> _fsm;
        public UnitState c_State;

        private Dictionary<UnitState, Callback> stateCallbacks = new Dictionary<UnitState, Callback>();

        List<>
        
        /// <summary>
        /// 
        /// </summary>

        public bool Alive
        {
            get
            {
                return _alv;
            }

            set
            {
                _alv = value;
            }
        }
 
        public int Attack
        {
            get
            {
                return _atk;
            }

            set
            {
                _atk = value;
            }
        }

        public int Defense
        {
            get
            {
                return _def;
            }

            set
            {
                _def = value;
            }
        }

        public int Health
        {
            get
            {
                return _hp;
            }

            set
            {
                _hp = value;
            }
        }

        public int MaxHealth
        {
            get
            {
                return _mhp;
            }

            set
            {
                _mhp = value;
            }
        }

        public int Speed
        {
            get
            {
                return _spd;
            }

            set
            {
                _spd = value;
            }
        }

        public FiniteStateMachine<UnitState> fsm
        {
            get
            {
                if (_fsm == null)
                    SetupMachine();
                return _fsm;
            }
        }

        // MonoBehaviour, i want this gone
        void Awake()
        {
            onInit();
        }

        public void onAttack(Combat.Unit other)
        {
            throw new NotImplementedException();
        }

        public void onDeath()
        {
            throw new NotImplementedException();
        }

        public void onHit()
        {
            //GuiManager.PopulateStats(hp, speed, favCookie);
            throw new NotImplementedException();
        }

        public void onInit()
        {
            //pull my abilities and populate the gui
            //GuiManager.PopulateStats(hp, speed, favCookie);
            RegisterCallback(UnitState.INIT, onInit);
            RegisterCallback(UnitState.START, onStart);
            anim = gameObject.GetComponentInChildren<Animator>();
        }

        public void onStart()
        {
            anim.SetTrigger("start");
            _fsm.Transition(UnitState.SELECTION);
        }

        /// <summary>
        /// Set up all valid Transistion
        /// </summary>
        public void SetupMachine()
        {
            _fsm = new FiniteStateMachine<UnitState>(UnitState.INIT);
            _fsm.AddTransition(UnitState.INIT,      UnitState.START);
            _fsm.AddTransition(UnitState.START,     UnitState.SELECTION);
            _fsm.AddTransition(UnitState.SELECTION, UnitState.TARGET);
            _fsm.AddTransition(UnitState.TARGET,    UnitState.SELECTION); //reflexive
            _fsm.AddTransition(UnitState.TARGET,    UnitState.RESOLVE);
            _fsm.AddTransition(UnitState.RESOLVE,   UnitState.END);
        }

        public void GoToState(UnitState to)
        {
            if (fsm.Transition(to))
                InvokeCallbacks(to);
        }

        public void RegisterCallback(UnitState state, Callback cb)
        {     
            stateCallbacks.Add(state, cb);
        }

        void InvokeCallbacks(UnitState state)
        {
            stateCallbacks[state]();
        }

        public void onAttack()
        {
            throw new NotImplementedException();
        }

        public void onSelection()
        {
            throw new NotImplementedException();
        }
    }
}