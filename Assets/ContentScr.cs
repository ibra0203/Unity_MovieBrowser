using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentScr : MonoBehaviour
{
    SearchInfo info;
    public GameObject MoviePrefab;
    public MovieIDEvent e_buttonPressed;
    public void setSearchInfo(SearchInfo _info)
    {
        info = _info;
        populateMovies();
    }
    void populateMovies()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        foreach(MovieSearchInfo m in info.Search)
        {
            GameObject obj = Instantiate(MoviePrefab, transform);
            obj.GetComponent<MovieScr>().setInfo(m);
            obj.GetComponent<MovieScr>().setButtonPressed(e_buttonPressed);

        }
    }
}
