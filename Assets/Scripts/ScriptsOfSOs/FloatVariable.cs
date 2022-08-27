using UnityEngine;

namespace MyGame.SO
{
    [CreateAssetMenu(fileName = "New FloatVariable", menuName = "Scriptable Objects/FloatVariable", order = 52)]
    public class FloatVariable : ScriptableObject
    {
        public float value;
        public void SetValue(float _value)
        {
            value = _value;
        }
    }
}
