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
            //Query 3: Вивести всі домашні матчі збірної Франції за 2021 рік, де вона зіграла у нічию.

            var selectedGames = from p in games
                                where p.Home_team == "France"
                                   && p.Country == "France"
                                   && p.Home_score == p.Away_score && p.Date.Year == 2021
                                select p;

            // Перевірка
            Console.WriteLine("\n======================== QUERY 3 ========================");

            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, score: {game.Home_score} : {game.Away_score}, Country: {game.Country}");
            }
        }

        // Запит 4
        static void Query4(List<FootballGame> games)
        {
            //Query 4: Вивести всі матчі збірної Германії з 2018 року по 2020 рік (включно), в яких вона на виїзді програла.

            var selectedGames = from p in games
                                where p.Away_team == "Germany"
                                   && p.Away_score < p.Home_score && p.Date.Year >= 2018 && p.Date.Year <= 2020
                                select p;


            // Перевірка
            Console.WriteLine("\n======================== QUERY 4 ========================");

            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, score: {game.Home_score} : {game.Away_score}, Country: {game.Country}");
            }
        }

        // Запит 5
        static void Query5(List<FootballGame> games)
        {
            //Query 5: Вивести всі кваліфікаційні матчі (UEFA Euro qualification), які відбулися у Києві чи у Харкові, а також за умови перемоги української збірної.


            var selectedGames = from p in games
                                where p.Home_team == "Ukraine"
                                   && p.Country == "Ukraine"
                                   && p.Home_score > p.Away_score
                                   && p.Tournament == "UEFA Euro qualification"
                                   && (p.City == "Kyiv" || p.City == "Kharkiv")
                                select p;


            // Перевірка
            Console.WriteLine("\n======================== QUERY 5 ========================");

            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, score: {game.Home_score} : {game.Away_score}, Country: {game.Country}");
            }
        }

        // Запит 6
        static void Query6(List<FootballGame> games)
        {
            //Query 6: Вивести всі матчі останнього чемпіоната світу з футболу (FIFA World Cup), починаючи з чвертьфіналів (тобто останні 8 матчів).
            //Матчі мають відображатися від фіналу до чвертьфіналів (тобто у зворотній послідовності).

            var selectedGames = from p in games
                                where p.Tournament == "FIFA World Cup"
                                select p;
            selectedGames = selectedGames.TakeLast(8).Reverse();

            // Перевірка
            Console.WriteLine("\n======================== QUERY 6 ========================");

            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.Date.ToShortDateString()} {game.Home_team} - {game.Away_team}, score: {game.Home_score} : {game.Away_score}, Country: {game.Country}");
            }
        }

        // Запит 7
        static void Query7(List<FootballGame> games)
        {
            //Query 7: Вивести перший матч у 2023 році, в якому збірна України виграла.
            var selectedGames = from p in games
                                where p.Date.Year == 2023
                                   && p.Away_team == "Ukraine"
                                   && p.Away_score > p.Home_score
                                select p;

            FootballGame g = selectedGames.First();


            // Перевірка
            Console.WriteLine("\n======================== QUERY 7 ========================");

            Console.WriteLine($"{g.Date.ToShortDateString()} {g.Home_team} - {g.Away_team}, score: {g.Home_score} : {g.Away_score}, Country: {g.Country}");
        }

        // Запит 8
        static void Query8(List<FootballGame> games)
        {
            //Query 8: Перетворити всі матчі Євро-2012 (UEFA Euro), які відбулися в Україні, на матчі з наступними властивостями:
            // MatchYear - рік матчу, Team1 - назва приймаючої команди, Team2 - назва гостьової команди, Goals - сума всіх голів за матч

            var selectedGames = from g in games
                                where g.Tournament == "UEFA Euro"
                                   && g.Country == "Ukraine"
                                select new
                                {
                                    MatchYear = g.Date.Year,
                                    Team1 = g.Home_team,
                                    Team2 = g.Away_team,
                                    Goals = g.Home_score + g.Away_score
                                };

            // Перевірка
            Console.WriteLine("\n======================== QUERY 8 ========================");

            foreach (var game in selectedGames)
            {
                Console.WriteLine($"{game.MatchYear} {game.Team1} - {game.Team2}, goals: {game.Goals}");
            }
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