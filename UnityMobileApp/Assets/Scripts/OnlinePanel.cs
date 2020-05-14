using UnityEngine;
using UnityEngine.UI;

public class OnlinePanel : MonoBehaviour
{
    public Image image;
    public Text text;

    public void SetOnline()
    {
        image.color = new Color(0.2728729f, 0.7924528f, 0.3084335f);
        text.text = "online";
    }

    public void SetOffline()
    {
        image.color = new Color(0.3803922f, 0.3803922f, 0.3803922f);
        text.text = "offline";
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
