using System;
using Microsoft.Data.Sqlite;

namespace DatabasPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqliteConnection(@"Data Source=../../../video_games_v03.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                $@"
                    SELECT Title, Year, Publishers, Review_Score, Sales
                    FROM video_games
                    ORDER by Sales DESC
                    LIMIT 10;
                ";

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var title = reader.GetString(0);
                        var year = reader.GetString(1);
                        var publishers = reader.IsDBNull(2) ? "" : reader.GetString(2);
                        var review_score = reader.GetString(3);
                        var sales = reader.GetString(4);

                        Console.WriteLine($"Game: {title}");
                        Console.WriteLine($"Year: {year}");
                        Console.WriteLine($"Publisher: {publishers}");
                        Console.WriteLine($"Review Score: {review_score}");
                        Console.WriteLine($"Sales: {sales}");
                        Console.WriteLine(" ");
                    }
                }
            }
        }
    }
}
