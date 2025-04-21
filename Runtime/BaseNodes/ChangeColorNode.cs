using System;
using FPS.StateGraph.Runtime.Core;
using UnityEngine;
using UnityEngine.UI;

namespace FPS.StateGraph.Runtime.BaseNodes
{
    public class ChangeColorNode : LeafNode<Image, ColorConfig>
    {
    }

    [Serializable]
    public class ColorConfig : StateConfig<Image>
    {
        [SerializeField] private Color _color;

        public override void Apply(Image target)
        {
            target.color = _color;
        }
    }
}