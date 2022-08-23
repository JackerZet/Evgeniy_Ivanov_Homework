using UnityEngine;

namespace MyGame.SO
{
    [CreateAssetMenu(fileName = "New IntVariable", menuName = "Scriptable Objects/IntVariable", order = 51)]
    public class IntVariable : ScriptableObject
    {
        public int value;
        public void SetValue(int _value)
        {
            value = _value;
        }
    }
}
