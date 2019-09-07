using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class SearchEvent : UnityEvent<SearchInfo>
{
     
}
[System.Serializable]
public class MovieIDEvent : UnityEvent<string>
{

}
[System.Serializable]
public class MovieInfoEvent : UnityEvent<MovieInfo>
{

}
public class EventManager : MonoBehaviour
{
    public GameObject SearchPanel, InfoPanel;
    public SearchEvent e_SearchInfoGet;
    public MovieInfoEvent e_MovieInfoGet;
   public void onSearchTextChanged(string txt)
    {
        StartCoroutine(gameObject.GetComponent<RequestManager>().GetMovies(txt));
    }

    public void onSearchInfoGet(SearchInfo info)
    {
        e_SearchInfoGet.Invoke(info);   
    }

    public void onMovieSelected(string id)
    {
        StartCoroutine(gameObject.GetComponent<RequestManager>().GetMovieInfo(id));

    }
    public void onMovieInfoGet(MovieInfo info)
    {
        InfoPanel.SetActive(true);
        SearchPanel.SetActive(false);
        e_MovieInfoGet.Invoke(info);
    }
    public void onBackButtonPressed()
    {
        InfoPanel.SetActive(false);
        SearchPanel.SetActive(true);
    }
}
