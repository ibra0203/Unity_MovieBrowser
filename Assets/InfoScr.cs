using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoScr : MonoBehaviour
{
    MovieInfo info;
   public void setMovieInfo(MovieInfo _info)
    {
        info = _info;
        Sprite sprite = Sprite.Create(info.texture, new Rect(0, 0, info.texture.width, info.texture.height), new Vector2(0.5f, 0.5f));
        transform.Find("Image").GetComponent<Image>().sprite = sprite;
        //    public string Title, Year, Rated, Released, Runtime, Genre, Poster;

        string txt = "Title: {0}\nYear: {1}\nRated: {2}\nReleased: {3}\nRuntime: {4}\nGenre: {5}\nDirector: {6}\nWriter: {7}\nPlot: {8}";
        txt = string.Format(txt, new object[] { info.Year, info.Year, info.Rated, info.Released, info.Runtime, info.Genre, info.Director,
        info.Writer, info.Plot});
        gameObject.GetComponentInChildren<Text>().text = txt;

    }
}
