using System;
using UnityEngine;

namespace FPS.StateGraph.Runtime.Core
{
    [Serializable]
    public abstract class StateConfig<T>
    {
        [SerializeField] private string _stateName;

        public string StateName
        {
            get => _stateName;
            set => _stateName = value;
        }

        public abstract void Apply(T target);
    }
}