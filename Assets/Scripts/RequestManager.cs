using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class RequestManager : MonoBehaviour
{
   public IEnumerator GetMovies(string q)
    {
        string uri = "http://www.omdbapi.com/?apikey=6367da97&s=" + q;
        using (UnityWebRequest r = UnityWebRequest.Get(uri))
        {
            yield return r.SendWebRequest();

            if(r.isHttpError || r.isNetworkError)
            {
                Debug.Log(r.error);
            }
            else
            {
                SearchInfo info = JsonUtility.FromJson<SearchInfo>(r.downloadHandler.text);

                if(info != null)
                {
                    foreach(MovieSearchInfo m in info.Search)
                    {
                        using (UnityWebRequest tr = UnityWebRequestTexture.GetTexture(m.Poster))
                        {
                            yield return tr.SendWebRequest();
                            if(tr.isHttpError || tr.isNetworkError)
                            {
                                Debug.Log(tr.error);
                            }
                            else
                            {
                                m.texture = DownloadHandlerTexture.GetContent(tr);
                            }
                        }
                    }
                    gameObject.GetComponent<EventManager>().onSearchInfoGet(info);
                }
            }
        }
    }

    public IEnumerator GetMovieInfo(string id)
    {
        string uri = "http://www.omdbapi.com/?apikey=6367da97&i=" + id;
        using (UnityWebRequest r = UnityWebRequest.Get(uri))
        {
            yield return r.SendWebRequest();

            if (r.isHttpError || r.isNetworkError)
            {
                Debug.Log(r.error);
            }
            else
            {
                MovieInfo info = JsonUtility.FromJson<MovieInfo>(r.downloadHandler.text);

                if (info != null)
                {
                    
                    using (UnityWebRequest tr = UnityWebRequestTexture.GetTexture(info.Poster))
                    {
                        yield return tr.SendWebRequest();
                        if (tr.isHttpError || tr.isNetworkError)
                        {
                            Debug.Log(tr.error);
                        }
                        else
                        {
                            info.texture = DownloadHandlerTexture.GetContent(tr);
                        }
                    }
                    
                    gameObject.GetComponent<EventManager>().onMovieInfoGet(info);
                }
            }
        }
    }
}
