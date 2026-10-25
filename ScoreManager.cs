public class ScoreManager
{
    private Dictionary<string, int> scores;
    private readonly string scoreFilePath = "hardScores.txt";

    public ScoreManager()
    {
        scores = new Dictionary<string, int>
            {
                { "circle", 0 },
                { "ekis", 0 }
            };
    }

    // increment score for a given player
    public void IncrementScore(string player)
    {
        if (scores.ContainsKey(player))
        {
            scores[player]++;
            WriteScoresToFile();
        }
    }

    // get the current score of a given player
    public int GetScore(string player)
    {
        if (scores.ContainsKey(player))
        {
            return scores[player];
        }

        return 0;
    }

    // reset scores for both players
    public void ResetScores()
    {
        scores["circle"] = 0;
        scores["ekis"] = 0;
        WriteScoresToFile();
    }

    // write scores to file
    private void WriteScoresToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(scoreFilePath, false))
            {
                foreach (var score in scores)
                {
                    writer.WriteLine($"{score.Key}: {score.Value}");
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
        }
    }
}