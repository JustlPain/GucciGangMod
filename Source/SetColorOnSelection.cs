﻿using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Examples/Set Color on Selection"), ExecuteInEditMode, RequireComponent(typeof(UIWidget))]
public class SetColorOnSelection : MonoBehaviour
{
    private static Dictionary<string, int> f__switchmap4;
    private UIWidget mWidget;

    private void OnSelectionChange(string val)
    {
        if (mWidget == null)
        {
            mWidget = GetComponent<UIWidget>();
        }

        var key = val;
        if (key != null)
        {
            int num;
            if (f__switchmap4 == null)
            {
                var dictionary = new Dictionary<string, int>(7);
                dictionary.Add("White", 0);
                dictionary.Add("Red", 1);
                dictionary.Add("Green", 2);
                dictionary.Add("Blue", 3);
                dictionary.Add("Yellow", 4);
                dictionary.Add("Cyan", 5);
                dictionary.Add("Magenta", 6);
                f__switchmap4 = dictionary;
            }

            if (f__switchmap4.TryGetValue(key, out num))
            {
                switch (num)
                {
                    case 0:
                        mWidget.color = Color.white;
                        break;

                    case 1:
                        mWidget.color = Color.red;
                        break;

                    case 2:
                        mWidget.color = Color.green;
                        break;

                    case 3:
                        mWidget.color = Color.blue;
                        break;

                    case 4:
                        mWidget.color = Color.yellow;
                        break;

                    case 5:
                        mWidget.color = Color.cyan;
                        break;

                    case 6:
                        mWidget.color = Color.magenta;
                        break;
                }
            }
        }
    }
}