using System;
using FPS.StateGraph.Runtime.Core;
using UnityEngine;
using UnityEngine.UI;

namespace FPS.StateGraph.Runtime.BaseNodes
{
    public class ChangeSpriteNode : LeafNode<Image, SpriteConfig>
    {
    }

    [Serializable]
    public class SpriteConfig : StateConfig<Image>
    {
        [SerializeField] private Sprite _sprite;

        public override void Apply(Image target)
        {
            target.sprite = _sprite;
        }
    }
}