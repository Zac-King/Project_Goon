using UnityEngine; 
using System;
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
        END,
    }
    /// <summary>
    /// Participates in combat
    /// contains stats for member
    /// </summary>
    public class Unit : MonoBehaviour, IUnit<UnitState>
    {
        void Start()
        {
            RegisterCallback(UnitState.INIT, onInit);
            RegisterCallback(UnitState.START, onStart);
        }
        //stats
        public bool Alive
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float Attack
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public float Defense
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        private FiniteStateMachine<UnitState> _fsm;
        /// <summary>
        /// make an fsm in this class and return it 
        /// Usage: Combat.Unit.fsm.currentState?
        /// </summary>
        public UnitState c_State;
        public FiniteStateMachine<UnitState> fsm
        {
            get
            {
                if (_fsm == null)
                    SetupMachine();
                return _fsm;                
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
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
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

    
        public void GoToState(UnitState to)
        {
            if (fsm.Transition(to))
                InvokeCallbacks(to);
        }

        public void onInit()
        {
            
        }

        //this is the actual value
        private float _hp, _spd;

        //simulate some input
        public float hp, spd;
        public void onStart()
        {
            GetComponentInChildren<Animator>().SetTrigger("start");
            //pull my abilities and populate the gui
            //GuiManager.PopulateStats(hp, speed, favCookie);
        }

        //events        
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


        private Dictionary<UnitState, Callback> stateCallbacks = new Dictionary<UnitState, Callback>();
        public void RegisterCallback(UnitState state, Callback cb)
        {     
            stateCallbacks.Add(state, cb);
        }
        void InvokeCallbacks(UnitState state)
        {
            stateCallbacks[state]();
        }

     
    }
}