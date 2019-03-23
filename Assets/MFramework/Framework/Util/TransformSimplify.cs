#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace MFramework
{
    public class TransformSimplify
    {
#if UNITY_EDITOR
        [MenuItem("MFramework/Example/4.Transform API简化", false, 4)]
#endif
        private static void MenuClicked()
        {
            GameObject gameObject = new GameObject();
            SetLocalPositionX(gameObject.transform, 5.0f);

            SetLocalPositionY(gameObject.transform, 5.0f);

            SetLocalPositionZ(gameObject.transform, 5.0f);

            var transform = new GameObject("transform").transform;
            Identity(transform);
        }
        public static void AddChild(Transform parentTrans, Transform childTrans)
        {
            childTrans.SetParent(parentTrans);
        }

        public static void Identity(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
            transform.localRotation = Quaternion.identity;
        }

        public static void SetLocalPositionX(Transform transform, float x)
        {
            var localPosition = transform.localPosition;
            localPosition.x = x;
            transform.localPosition = localPosition;
        }

        public static void SetLocalPositionY(Transform transform, float y)
        {
            var localPosition = transform.localPosition;
            localPosition.y = y;
            transform.localPosition = localPosition;
        }

        public static void SetLocalPositionZ(Transform transform, float z)
        {
            var localPosition = transform.localPosition;
            localPosition.z = z;
            transform.localPosition = localPosition;
        }

        public static void SetLocalPositionXY(Transform transform, float x, float y)
        {
            var localPosition = transform.localPosition;
            localPosition.x = x;
            localPosition.y = y;
            transform.localPosition = localPosition;
        }

        public static void SetLocalPositionXZ(Transform transform, float x, float z)
        {
            var localPosition = transform.localPosition;
            localPosition.x = x;
            localPosition.z = z;
            transform.localPosition = localPosition;
        }

        public static void SetLocalPositionYZ(Transform transform, float y, float z)
        {
            var localPosition = transform.localPosition;
            localPosition.y = y;
            localPosition.z = z;
            transform.localPosition = localPosition;
        }
    }

}

