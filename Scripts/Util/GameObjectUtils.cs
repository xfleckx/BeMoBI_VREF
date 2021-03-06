﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.VREF.Scripts.Util
{
    public static class GameObjectUtils
    {
        public static IEnumerable<GameObject> AllChildren(this Transform parent)
        {
            var list = new List<GameObject>();

            for (int i = 0; i < parent.childCount; i++)
            {
                list.Add(parent.GetChild(i).gameObject);
            }

            return list;
        }

        /// <summary>
        /// Iterate over all Children GameObjects
        /// </summary>
        /// <param name="parent">The transform which children are requested</param>
        /// <returns>yield the next children on next call</returns>
        public static IEnumerator<GameObject> AllChildrenLazy(this Transform parent)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                yield return parent.GetChild(i).gameObject;
            }

            yield return null;
        }


    }
}
