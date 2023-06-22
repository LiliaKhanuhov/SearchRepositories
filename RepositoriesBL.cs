namespace RepositoriesManager
{
    public class RepositoriesBL
    {
        public dynamic PerformSearchAsync(string key)
        {
            HttpHelper httpHelper = new HttpHelper();
            var result = httpHelper.Get($"https://api.github.com/search/repositories?q={key}").Result;

            return result;
        }
    }
}

