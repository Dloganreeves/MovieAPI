using Newtonsoft.Json;
using System.Net;

namespace OMDB.Models
{
    public class MovieDAL
    {
        public static MovieModel GetMovies(string movie)
        {
            //adjust 
            //setup
            //API Key is here,but I know how to hide it.
            string url = $"http://www.omdbapi.com/?apikey=f4c13aad&t={movie}";

            //request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert to Json 
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //adjust
            //convert to c#
            MovieModel movies = JsonConvert.DeserializeObject<MovieModel>(JSON);
            return movies;
        }
    }
}

