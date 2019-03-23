using UnityEngine;

namespace MFramework
{
    public class TransformSimplifyExample
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("MFramework/Example/4.Transform API简化", false, 4)]
#endif
        private static void MenuClicked()
        {
            GameObject gameObject = new GameObject();
            TransformSimplify.SetLocalPositionX(gameObject.transform, 5.0f);

            TransformSimplify.SetLocalPositionY(gameObject.transform, 5.0f);

            TransformSimplify.SetLocalPositionZ(gameObject.transform, 5.0f);

            var transform = new GameObject("transform").transform;
            TransformSimplify.Identity(transform);
            //
            var parentTrans = new GameObject("ParentTransform").transform;
            var childTrans = new GameObject("ChildTransform").transform;

            TransformSimplify.AddChild(parentTrans, childTrans);
        }
    }

}
 