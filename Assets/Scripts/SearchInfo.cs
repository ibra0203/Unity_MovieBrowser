using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SearchInfo 
{
    public MovieSearchInfo[] Search;
}

[System.Serializable]
public class MovieSearchInfo
{
    public string Title, Year, imdbID, Type, Poster;
    public Texture2D texture;
}

[System.Serializable]
public class MovieInfo
{
    public string Title, Year, Rated, Released, Runtime, Genre, Director, Writer, Plot, Poster;
    public Texture2D texture;

}