using Newtonsoft.Json;

namespace Practice_Linq
{
    public class Program
    {
        static void Main(string[] args)
        {

            string path = @"../../../data/results_2010.json";

            List<FootballGame> games = ReadFromFileJson(path);

            int test_count = games.Count();
            Console.WriteLine($"Test value = {test_count}.");    // 13049

            Query1(games);
            Query2(games);
            Query3(games);
            Query4(games);
            Query5(games);
            Query6(games);
            Query7(games);
            Query8(games);
            Query9(games);
            Query10(games);
        }


        // Десеріалізація json-файлу у колекцію List<FootballGame>
        static List<FootballGame> ReadFromFileJson(string path)
        {

            var reader = new StreamReader(path);
            string jsondata = reader.ReadToEnd();

            List<FootballGame> games = JsonConvert.DeserializeObject<List<FootballGame>>(jsondata);


            return games;

        }


        // Запит 1
        static void Query1(List<FootballGame> games)
        {
            //Query 1: Вивести всі матчі, які відбулися в Україні у 2012 році.

            var selectedGames = games.Where(p => p.Country == "Ukraine" && p.Date.Year == 2012);


            // Перевірка
            Console.WriteLine("\n======================== QUERY 1 ========================");

            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, score: {game.Home_score} : {game.Away_score}, Country: {game.Country}");
            }
        }

        // Запит 2
        static void Query2(List<FootballGame> games)
        {
            //Query 2: Вивести Friendly матчі збірної Італії, які вона провела з 2020 року.  

            var selectedGames = games.Where(p => p.Country == "Italy" && p.Date.Year >= 2020 && p.Neutral == true);


            // Перевірка
            Console.WriteLine("\n======================== QUERY 2 ========================");

            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, score: {game.Home_score} : {game.Away_score}, Country: {game.Country}");
            }
        }

        // Запит 3
        static void Query3(List<FootballGame> games)
        {
           
        }

        // Запит 4
        static void Query4(List<FootballGame> games)
        {
           
        }

        // Запит 5
        static void Query5(List<FootballGame> games)
        {
           
        }

        // Запит 6
        static void Query6(List<FootballGame> games)
        {
           
        }

        // Запит 7
        static void Query7(List<FootballGame> games)
        {
            
        }

        // Запит 8
        static void Query8(List<FootballGame> games)
        {
            
        }

        // Запит 9
        static void Query9(List<FootballGame> games)
        {
           
        }

        // Запит 10
        static void Query10(List<FootballGame> games)
        {
           
        }
    }
}