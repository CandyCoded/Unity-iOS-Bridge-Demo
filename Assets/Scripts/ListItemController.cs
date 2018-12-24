using UnityEngine;
using UnityEngine.UI;

public class ListItemController : MonoBehaviour
{

    [SerializeField]
    private Text label;

    [SerializeField]
    private Text value;

    public void SetLabel(string text)
    {

        label.text = text;

    }

    public void SetValue(string text)
    {

        value.text = text;

    }

}
