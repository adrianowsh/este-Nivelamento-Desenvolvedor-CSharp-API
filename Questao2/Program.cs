using Newtonsoft.Json;
using Questao2;
using System.Text;

public class Program
{
    private const string apiUrl = "https://jsonmock.hackerrank.com/api/football_matches";
    internal static HttpClient httpClient = new()
    {
        BaseAddress = new Uri(apiUrl),
    };

    public static async Task Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        int goalsTeam = 0;
        var jsonResponse = await GetResultApi(team, year, default);
        if (jsonResponse is not null)
        {
            goalsTeam += SumGoalsFromResponse(jsonResponse);
            for (int i = 2; i <= jsonResponse.TotalPage; i++)
            {
                var response = await GetResultApi(team, year, i);
                goalsTeam += SumGoalsFromResponse(response);
            }
            return goalsTeam;
        }
        return 0;
    }

    public static int SumGoalsFromResponse(Result response)
    {
        return response.Data.SelectMany(p => p.Team1Goals).Select(p => int.Parse(p.ToString())).Sum();
    }

    public static async Task<Result> GetResultApi(string team, int year, int page)
    {
        var sbUrl = new StringBuilder();

        _ = page == default ? sbUrl.Append($"?year={year}&team1={team}")
                               : sbUrl.Append($"?year={year}&team1={team}&page={page}");

        using HttpResponseMessage response = await httpClient.GetAsync(sbUrl.ToString());
        if (response.IsSuccessStatusCode)
        {
            var stringMessage = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonConvert.DeserializeObject<Result>(stringMessage);
            return jsonResponse;
        }
        return new Result();
    }
}