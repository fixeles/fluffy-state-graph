using UnityEngine;

namespace FPS.StateGraph.Runtime.Core
{
    public abstract class StateNode : MonoBehaviour
    {
        [SerializeField, Min(0)] protected int _currentState;
        public abstract int State { set; get; }
        public abstract bool HasState(string stateName, out int stateIndex);
        protected abstract int StatesCount { get; }

        protected virtual void OnValidate()
        {
            if (StatesCount == 0)
                _currentState = 0;

            State = _currentState;
        }
    }
}