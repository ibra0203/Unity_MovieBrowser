using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovieScr : MonoBehaviour
{
    MovieSearchInfo info;
    MovieIDEvent e_buttonPressed;
    public void setButtonPressed(MovieIDEvent btnEvnt)
    {
        e_buttonPressed = btnEvnt;
    }
    public void setInfo(MovieSearchInfo _info)
    {
        info = _info;
        gameObject.GetComponentInChildren<Text>().text = info.Title;
        Sprite sprite = Sprite.Create(info.texture, new Rect(0, 0, info.texture.width, info.texture.height), new Vector2(0.5f, 0.5f));
        transform.Find("Image").GetComponent<Image>().sprite = sprite;
    }

    public void onButtonPressed()
    {
        e_buttonPressed.Invoke(info.imdbID);
    }

}
