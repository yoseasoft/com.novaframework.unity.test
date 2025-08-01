
using UnityEngine;

namespace Game.Pack
{
    /// <summary>
    /// 演示案例总控
    /// </summary>
    public class TestObject : MonoBehaviour
    {
        protected virtual void Awake()
        {
            Debug.LogWarning("test object awake !!!");
        }
    }
}
