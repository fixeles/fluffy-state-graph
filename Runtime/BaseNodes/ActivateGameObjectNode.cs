using System;
using FPS.StateGraph.Runtime.Core;
using UnityEngine;

namespace FPS.StateGraph.Runtime.BaseNodes
{
    public class ActivateGameObjectNode : LeafNode<GameObject, ActiveConfig>
    {
    }

    [Serializable]
    public class ActiveConfig : StateConfig<GameObject>
    {
        [SerializeField] private bool _isActive;

        public override void Apply(GameObject target)
        {
            target.SetActive(_isActive);
        }
    }
}