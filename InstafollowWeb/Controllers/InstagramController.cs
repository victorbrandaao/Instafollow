using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class InstagramController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(List<IFormFile> files)
    {
        if (files == null || files.Count != 2)
        {
            ViewBag.Message = "Por favor, selecione os dois arquivos (followers_1.json e following.json).";
            return View("Index");
        }

        var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
        Directory.CreateDirectory(uploadsPath);

        string? followersFilePath = null;
        string? followingFilePath = null;

        foreach (var file in files)
        {
            var filePath = Path.Combine(uploadsPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            if (file.FileName == "followers_1.json")
                followersFilePath = filePath;
            else if (file.FileName == "following.json")
                followingFilePath = filePath;
        }

        if (followersFilePath == null || followingFilePath == null)
        {
            ViewBag.Message = "Os arquivos followers_1.json e/ou following.json não foram encontrados.";
            return View("Index");
        }

        try
        {
            var (nonFollowers, nonFollowings) = CompareJsonFiles(followingFilePath, followersFilePath);
            TempData["NonFollowers"] = nonFollowers;
            TempData["NonFollowings"] = nonFollowings;
        }
        catch
        {
            ViewBag.Message = "Erro ao processar os arquivos. Verifique o formato JSON.";
            return View("Index");
        }

        return RedirectToAction("ShowNonMutuals");
    }

    [HttpGet]
    public IActionResult ShowNonMutuals()
    {
        var nonFollowers = TempData["NonFollowers"] as List<string> ?? new List<string>();
        var nonFollowings = TempData["NonFollowings"] as List<string> ?? new List<string>();

        ViewBag.NonFollowers = nonFollowers;
        ViewBag.NonFollowings = nonFollowings;

        return View("ShowNonMutuals");
    }

    private (List<string> NonFollowers, List<string> NonFollowings) CompareJsonFiles(string followingPath, string followersPath)
    {
        var followingList = ReadJsonFile(followingPath);
        var followersList = ReadJsonFile(followersPath);

        if (followingList == null || followersList == null)
            throw new InvalidDataException("Erro ao ler os arquivos JSON.");

        var nonFollowers = followingList.Except(followersList).ToList();
        var nonFollowings = followersList.Except(followingList).ToList();

        return (nonFollowers, nonFollowings);
    }

    private List<string> ReadJsonFile(string path)
    {
        var jsonData = System.IO.File.ReadAllText(path);

        if (path.Contains("following"))
        {
            var jsonObject = JsonConvert.DeserializeObject<FollowingRootObject>(jsonData);
            return jsonObject?.RelationshipsFollowing?
                .SelectMany(item => item.StringListData?.Select(data => data.Value) ?? Enumerable.Empty<string?>())
                .Where(username => !string.IsNullOrEmpty(username))
                .Cast<string>()
                .ToList() ?? new List<string>();
        }
        else
        {
            var jsonObject = JsonConvert.DeserializeObject<List<RootObject>>(jsonData);
            return jsonObject?
                .SelectMany(item => item.StringListData?.Select(data => data.Value) ?? Enumerable.Empty<string?>())
                .Where(username => !string.IsNullOrEmpty(username))
                .Cast<string>()
                .ToList() ?? new List<string>();
        }
    }
}

public class FollowingRootObject
{
    public List<Relationship> RelationshipsFollowing { get; set; }
}

public class Relationship
{
    public List<StringListData> StringListData { get; set; }
}

public class StringListData
{
    public string Value { get; set; }
}

public class RootObject
{
    public List<StringListData> StringListData { get; set; }
}