using UnityEngine;

namespace FPS.StateGraph.Runtime.Core
{
    public class BranchNode : StateNode
    {
        [SerializeField] private StateNode[] _childNodes;

        public override int State
        {
            get => _currentState;
            set
            {
                if (_childNodes == null || _childNodes.Length == 0)
                    return;

                var state = Mathf.Clamp(value, 0, _childNodes.Length);
                _currentState = value;

                foreach (var childNode in _childNodes)
                {
                    if (childNode != null)
                        childNode.State = state;
                }
            }
        }

        public override bool HasState(string stateName, out int stateIndex)
        {
            foreach (var childNode in _childNodes)
            {
                if (!childNode.HasState(stateName, out stateIndex))
                    continue;

                return true;
            }
            stateIndex = -1;
            return false;
        }

        protected override int StatesCount => _childNodes?.Length ?? 0;

        public void TrySetState(string stateName)
        {
            if (HasState(stateName, out var stateIndex))
                State = stateIndex;
            else
                Debug.LogError($"State {stateName} not found");
        }
    }
}