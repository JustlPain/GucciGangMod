//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class AnimatedAlpha : MonoBehaviour
{
    public float alpha = 1f;
    private UIPanel mPanel;
    private UIWidget mWidget;

    private void Awake()
    {
        mWidget = GetComponent<UIWidget>();
        mPanel = GetComponent<UIPanel>();
        Update();
    }

    private void Update()
    {
        if (mWidget != null)
        {
            mWidget.alpha = alpha;
        }
        if (mPanel != null)
        {
            mPanel.alpha = alpha;
        }
    }
}

