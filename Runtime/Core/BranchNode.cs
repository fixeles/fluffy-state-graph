using UnityEngine;

namespace FPS.StateGraph.Runtime.Core
{
    public class BranchNode : StateNode
    {
        [SerializeField] private StateNode[] _childNodes;

        public override void SetState(int stateId)
        {
            if (_childNodes == null || _childNodes.Length == 0)
                return;

            var state = Mathf.Clamp(stateId, 0, _childNodes.Length);
            _currentState = stateId;

            foreach (var childNode in _childNodes)
            {
                if (childNode != null)
                    childNode.SetState(state);
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
                SetState(stateIndex);
            else
                Debug.LogError($"State {stateName} not found");
        }
    }
}