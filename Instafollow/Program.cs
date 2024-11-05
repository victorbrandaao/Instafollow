using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

class InstagramFollowers
{
    static void Main()
    {
        try
        {
            var data = LoadJson("caminho/para/seu/arquivo.json");
            var followers = ExtractList(data, "followers");
            var following = ExtractList(data, "following");

            var mutualFollowers = FindMutualFollowers(followers, following);
            var unfollowers = FindUnfollowers(following, followers);

            DisplayResults("Seguidores mútuos:", mutualFollowers);
            DisplayResults("\nUsuários que deixaram de seguir:", unfollowers);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static JObject LoadJson(string path)
    {
        return JObject.Parse(File.ReadAllText(path));
    }

    static List<string> ExtractList(JObject data, string key)
    {
        return data[key].ToObject<List<string>>();
    }

    static List<string> FindMutualFollowers(List<string> followers, List<string> following)
    {
        return followers.FindAll(following.Contains);
    }

    static List<string> FindUnfollowers(List<string> following, List<string> followers)
    {
        return following.FindAll(f => !followers.Contains(f));
    }

    static void DisplayResults(string message, List<string> list)
    {
        Console.WriteLine(message);
        list.ForEach(Console.WriteLine);
    }
}