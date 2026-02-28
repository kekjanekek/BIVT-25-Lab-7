namespace Lab7.Blue
{
    public class Task4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;
            public string Name => _name;
            public int TotalScore => _scores.Sum();
            public int[] Scores
            {
                get
                {
                    int[] copy = new int[_scores.Length];
                    Array.Copy(_scores, 0,copy,0, _scores.Length);
                    return copy;
                }
            }
 
            public Team (string name)
            {
                _name = name;
                _scores = [];
            }
            public void PlayMatch(int result)
            {
                Array.Resize(ref _scores, _scores.Length+1);
                _scores[^1] = result;
            }
            public void Print()
            {
                return;
            }
        }
        public struct Group
        {
            private string _name;
            private int _count;
            private Team[] _teams;
            public string Name => _name;
            public Team[] Teams
            {
                get
                {
                    Team[] copy = new Team[_teams.Length];//тут team потому что тим это коробка где нахолится названеи группы и баллы поэтому оттуда создаем и засовываем 
                    Array.Copy(_teams, 0, copy, 0, _teams.Length); return copy;
                }
            }
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _count = 0;
            }
            public void Add(Team team) //1 команда
            {
                if (_count >= 12) return;
                else
                {
                    _teams[_count] = team;
                    _count++;
                }
            }
            public void Add(Team[] teams)
            {
                foreach (var team in teams)
                {
                    if (_count < 12)
                    {
                        _teams[_count] = team;
                        _count++;
                    }
                    else return;
                }
            }
            public void Sort()//сортировка по убыванию
            {
                for (int i = 0; i < _teams.Length-1; i++)
                {
                    for (int j = 0; j < _teams.Length - 1 - i; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                            (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                    }
                }
            }
 
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                group1.Sort();
                group2.Sort();
                int countTeam = size / 2;
                for (int i = 0; i< countTeam; i++)
                {
                    result.Add(group1._teams[i]);
                    result.Add(group2._teams[i]);
                }
                result.Sort();
                return result;
            }
            public void Print()
            {
                return;
            }
        }
    }

}
 
