//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using UnityEngine;

public class PanelResult : MonoBehaviour
{
    public GameObject label_quit;
    private int lang = -1;

    private void OnEnable()
    {
    }

    private void showTxt()
    {
        if (lang != Language.type)
        {
            lang = Language.type;
            label_quit.GetComponent<UILabel>().text = Language.btn_quit[Language.type];
        }
    }

    private void Update()
    {
        showTxt();
    }
}

