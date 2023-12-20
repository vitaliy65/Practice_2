# Завдання з LINQ у футбольному проєкті

## Опис проєкту

Цей проєкт містить частковий код, який описує футбольні матчі, та включає методи для виконання запитів за допомогою LINQ.

### Завдання

1. **Клонування репозиторію**: Для отримання початкового коду склонуйте [репозиторій](https://github.com/IlonaShevchenko/Practice_Linq.git).
2. **Вже реалізовано**: 
    - Метод `ReadFromFileJson()`, який десеріалізує json-файл (data/results_2010.json) у колекцію `List<FootballGame>`.
    - Метод `Main()`, що виводить на екран тестове значення 13049 (кількість всіх матчів збірних з 2010 року).
3. **Реалізація методів Query1()...Query10()**: Кожен метод має відповідати певному запиту і виводити результати на екран.
4. **Коміти у репозиторій**: Після кожного реалізованого методу `QueryN()` необхідно зробити коміт, зазначивши номер N реалізованого запиту.

## Реалізація запитів

### Query 1: Матчі в Україні у 2012 році
```csharp
var selectedGames = games.Where(p => p.Country == "Ukraine" && p.Date.Year == 2012);
```
### Query 2: Friendly матчі Італії з 2020 р.
```csharp
var selectedGames = games.Where(p => p.Country == "Italy" && p.Date.Year >= 2020 && p.Neutral == true);
```
### Query 3: Домашні матчі Франції у 2021 р.
```csharp
var selectedGames = from p in games
                    where p.Home_team == "France"
                       && p.Country == "France"
                       && p.Home_score == p.Away_score && p.Date.Year == 2021
                    select p;
```
### Query 4: Матчі Германії з 2018 по 2020 рр.
```csharp
var selectedGames = from p in games
                    where p.Away_team == "Germany"
                       && p.Away_score < p.Home_score && p.Date.Year >= 2018 && p.Date.Year <= 2020
                    select p;
```
### Query 5: Кваліфікаційні матчі UEFA Euro в Україні
```csharp
var selectedGames = from p in games
                    where p.Home_team == "Ukraine"
                       && p.Country == "Ukraine"
                       && p.Home_score > p.Away_score
                       && p.Tournament == "UEFA Euro qualification"
                       && (p.City == "Kyiv" || p.City == "Kharkiv")
                    select p;;
```
### Query 6: Матчі чемпіонату світу з футболу
```csharp
var selectedGames = from p in games
                    where p.Tournament == "FIFA World Cup"
                    select p;
selectedGames = selectedGames.TakeLast(8).Reverse();
```
### Query 7: Перший матч України у 2023 році, що виграла
```csharp
var selectedGames = from p in games
                    where p.Date.Year == 2023
                       && p.Away_team == "Ukraine"
                       && p.Away_score > p.Home_score
                    select p;
FootballGame g = selectedGames.First();
```
### Query 8: Матчі Євро-2012 в Україні
```csharp
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
```
### Query 9: Матчі UEFA Nations League у 2023 році
```csharp
var selectedGames = from g in games
                    where g.Tournament == "UEFA Nations League"
                       && g.Date.Year == 2023
                    select new
                    {
                        MatchYear = g.Date.Year,
                        Game = $"{g.Home_team} - {g.Away_team}",
                        Result = (g.Home_score > g.Away_score) ? "Win" :
                                 (g.Home_score < g.Away_score) ? "Loss" : "Draw"
                    };
```
### Query 10: Матчі Gold Cup у липні 2023 р.
```csharp
var selectedGames = games.Where(g => g.Date.Year == 2023 && g.Date.Month == 7 && g.Tournament == "Gold Cup").Skip(4).Take(6);
