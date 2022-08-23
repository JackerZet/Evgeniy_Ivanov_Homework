using UnityEngine;

namespace MyGame.SO.Events
{
    public abstract class DescriptionBase : ScriptableObject
    {
        [TextArea]
        [SerializeField] private string description;
    }
}