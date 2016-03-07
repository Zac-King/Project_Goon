using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Combat 
{//this is a user
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
        public float  mhp,  hp,  atk,  def,  spd;
        bool  alv;

        //this is the actual value
        private float _mhp, _hp, _atk, _def, _spd;
        bool _alv;

        private FiniteStateMachine<UnitState> _fsm;
        public UnitState c_State;

        private Dictionary<UnitState, Callback> stateCallbacks = new Dictionary<UnitState, Callback>();

        // MonoBehaviour, i want this gone
        void Start()
        {
            RegisterCallback(UnitState.INIT, onInit);
            RegisterCallback(UnitState.START, onStart);
        }

        /// <summary>
        /// 
        /// </summary>
#pragma region Stats
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

        public float Attack
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

        public float Defense
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

        public float Health
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

        public float MaxHealth
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

        public float Speed
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
#pragma endregion

        /// <summary>
        /// 
        /// </summary>
#pragma region Events
        public void onAttack()
        {
            Debug.Log("Attack! " + gameObject.name);
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

        }

        public void onStart()
        {
            GetComponentInChildren<Animator>().SetTrigger("start");
            //pull my abilities and populate the gui
            //GuiManager.PopulateStats(hp, speed, favCookie);
        }
#pragma endregion

        /// <summary>
        /// 
        /// </summary>
#pragma region Machine
        public void SetupMachine()
        {
            _fsm = new FiniteStateMachine<UnitState>(UnitState.INIT);
            _fsm.AddTransition(UnitState.INIT, UnitState.START);
            _fsm.AddTransition(UnitState.START, UnitState.SELECTION);
            _fsm.AddTransition(UnitState.SELECTION, UnitState.TARGET);
            _fsm.AddTransition(UnitState.TARGET, UnitState.SELECTION); //reflexive
            _fsm.AddTransition(UnitState.TARGET, UnitState.RESOLVE);
            _fsm.AddTransition(UnitState.RESOLVE, UnitState.END);
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
#pragma endregion
    }
}