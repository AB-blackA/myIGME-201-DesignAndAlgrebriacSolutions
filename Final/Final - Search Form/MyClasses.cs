using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___Search_Form
{
    internal class MyClasses
    {

        // Represents a game
        public class Game
        {
            public string Name { get; set; }
            public List<string> Platforms { get; set; }

            public Game(string name, List<string> platforms)
            {
                Name = name;
                Platforms = platforms;
            }
        }

        // Represents a game not found
        public class GameNotFound
        {
        }

        // Represents a collection of games
        public class Games
        {
            private List<Game> games;

            public Games()
            {
                games = new List<Game>();
            }

            public void AddGame(Game game)
            {
                games.Add(game);
            }

            public void AddGameNotFound()
            {
                // Add logic for handling game not found
            }
        }

        // Represents a database of games
        public class GameDatabase
        {
            private Dictionary<Games, string> games;
            private Searcher search;

            public GameDatabase(Searcher searcher)
            {
                games = new Dictionary<Games, string>();
                search = searcher;
            }

            public KeyValuePair<Games, string> ReturnSearch(Game game)
            {
                // Add logic to search for a game in the database
                return new KeyValuePair<Games, string>(new Games(), "Found");
            }

            public void AddGame(Game game, string info)
            {
                // Add logic to add a game to the database
            }
        }

        // Represents a team
        public class Team
        {
            // Team properties
        }

        // Represents a team not found
        public class TeamNotFound
        {
        }

        // Represents a collection of teams
        public class Teams
        {
            private List<Team> teams;

            public Teams()
            {
                teams = new List<Team>();
            }

            public void AddTeam(Team team)
            {
                teams.Add(team);
            }

            public void AddTeamNotFound()
            {
                // Add logic for handling team not found
            }
        }

        // Represents a database of teams
        public class TeamDatabase
        {
            private List<Teams> teams;
            private Searcher search;

            public TeamDatabase(Searcher searcher)
            {
                teams = new List<Teams>();
                search = searcher;
            }

            public Teams ReturnTeamsByGame(Game game)
            {
                // Add logic to return teams based on a game
                return new Teams();
            }

            public void AddGameToMyTeam(KeyValuePair<Game, string> gameInfo)
            {
                // Add logic to add a game to the team database
            }
        }

        // Represents a query for game requests
        public class RequestQuery
        {
            private Dictionary<string, string> gameRequests;

            public RequestQuery()
            {
                gameRequests = new Dictionary<string, string>();
            }

            public void AddRequest(string gameName)
            {
                // Add logic to add a game request
            }

            public void AddRequest(string gameName, string console)
            {
                // Add logic to add a game request with platform
            }

            public void AddRequest(KeyValuePair<string, string> gameInfo)
            {
                // Add logic to add a game request with additional information
            }
        }

        // Represents a requester
        public class Requester
        {
            private KeyValuePair<string, string> requestInfo;
            private RequestQuery rq;
            private Searcher search;

            public Requester(RequestQuery requestQuery, Searcher searcher)
            {
                rq = requestQuery;
                search = searcher;
            }

            public void Search()
            {
                // Add logic to initiate a search
            }

            public void RQ()
            {
                // Access the RequestQuery object
            }

            public void AddRequest(string gameName)
            {
                // Add logic to add a game request
            }

            public void AddRequest(string gameName, string console)
            {
                // Add logic to add a game request with platform
            }

            public void AddRequest(KeyValuePair<string, string> gameInfo)
            {
                // Add logic to add a game request with additional information
            }
        }

        // Represents a user interface
        public class UserInterface
        {
            private Searcher search;

            public UserInterface(Searcher searcher)
            {
                search = searcher;
            }

            public void Search()
            {
                // Add logic to initiate a search
            }

            public void AskToAddTeam()
            {
                // Add logic to prompt the user to add a team
            }

            public void AskToAddGame()
            {
                // Add logic to prompt the user to add a game
            }
        }

        // Represents a searcher
        public class Searcher
        {
            private KeyValuePair<Game, string> foundGames;
            private List<Team> foundTeams;
            private GameDatabase gameDB;
            private TeamDatabase teamDB;
            private Requester requester;
            private UserInterface ui;

            public Searcher(UserInterface userInterface, Requester request, GameDatabase gameDatabase, TeamDatabase teamDatabase)
            {
                ui = userInterface;
                requester = request;
                gameDB = gameDatabase;
                teamDB = teamDatabase;
            }

            public KeyValuePair<Game, string> SearchGame(string gameName)
            {
                // Add logic to search for a game
                return new KeyValuePair<Game, string>(new Game(gameName, new List<string>()), "Found");
            }

            public KeyValuePair<Game, string> SearchGame(string gameName, string platform)
            {
                // Add logic to search for a game with platform
                return new KeyValuePair<Game, string>(new Game(gameName, new List<string> { platform }), "Found");
            }

            public Team SearchTeam(KeyValuePair<Game, string> gameInfo)
            {
                // Add logic to search for a team based on a game
                return new Team();
            }
        }


    }
}
