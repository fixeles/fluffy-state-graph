using UnityEngine;

namespace FPS.StateGraph.Runtime.Core
{
    public abstract class LeafNode<TTarget, TConfig> : StateNode
        where TTarget : Object
        where TConfig : StateConfig<TTarget>
    {
        [SerializeField] private TTarget _target;
        [SerializeField] private TConfig[] _states;

        public override void SetState(int stateId)
        {
            if (_states == null || _states.Length == 0)
                return;

            stateId = Mathf.Clamp(stateId, 0, _states.Length - 1);
            _currentState = stateId;
            _states[stateId].Apply(_target);
        }

        public override bool HasState(string stateName, out int stateIndex)
        {
            for (int i = 0; i < _states.Length; i++)
            {
                if (_states[i].StateName != stateName)
                    continue;

                stateIndex = i;
                return true;
            }
            stateIndex = -1;
            return false;
        }

        protected override int StatesCount => _states?.Length ?? 0;

        protected override void OnValidate()
        {
            base.OnValidate();
            _target ??= GetComponent<TTarget>();
        }
    }
}