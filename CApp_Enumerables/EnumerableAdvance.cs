using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Enumerables
{
    internal class EnumerableAdvance
    {
        public void Main(string[] args)
        {
            Team team = new Team();

            List<Player> filtered = team.Where(t => t.LastName.Contains('1')).ToList<Player>();

            foreach (Player item in filtered)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Team : IEnumerable<Player>
    {
        private readonly IList<Player> _players = new List<Player> { new Player("Player", "11"), new Player("Player", "21") };

        private TeamEnumerator _enumerator;

        public Team()
        {
            _enumerator = new TeamEnumerator(_players);
        }

        IEnumerator<Player> IEnumerable<Player>.GetEnumerator()
        {
            return _enumerator;
        }

        public IEnumerator GetEnumerator()
        {
            return _enumerator;
        }

        public ICollection<string> Trainers { get; set; }

    }

    public class TeamEnumerator : IEnumerator<Player>
    {
        private readonly IList<Player> _players;

        private int Index { get; set; }

        public TeamEnumerator(IList<Player> players)
        {
            _players = players;
            Index = -1;
        }

        public Player Current { get; set; }
        
        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Index = 0;
            Current = _players[0];
        }

        public bool MoveNext()
        {
            Index++;

            if(_players.Count > Index)
                Current = _players[Index];

            return _players.Count > Index;            
        }

        public void Reset()
        {
            Current = _players[0];
        }
    }

    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Player(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{FirstName} -- {LastName}";
        }
    }
}
