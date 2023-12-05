using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Joje.Scripts
{
    public static class TransformExtensions
    {
        public static bool TryGetAllChildren(this Transform transform, Transform[] children)
        {
            int childCount = transform.childCount;
            children = new Transform[childCount];
            for (int i = 0; i < childCount; i++)
            {
                children[i] = transform.GetChild(i);
            }
            return childCount > 0;
        }
        
        // public static bool TryGetAllActiveChildren(out Transform[] children)
        // public static bool TryGetChildren(condition, out Transform child)

        public static List<Transform> GetChildrenWithCondition(this Transform parent, Func<Transform, bool> condition)
        {
            // int childCount = parent.childCount;
            List<Transform> filteredChildren = new List<Transform>(parent.childCount);
            filteredChildren.AddRange(parent.Cast<Transform>().Where(condition));
            return filteredChildren;
        }
    }
}