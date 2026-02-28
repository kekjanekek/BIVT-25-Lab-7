namespace Lab7.Blue
{
    public class Task2
    {public struct Participant
    {
        // приватные поля только мои никто не трогает 
        private string _name;
        private string _surname;
        private int[,] _marks; //матрица 5 судей 2 прыжка 
        private bool _fjump;
        private bool _sjump;

        
        //свойства приват в публик
        public string Name => _name;
        public string Surname => _surname;

        public int[,] Marks
        {
            get
            {
                int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                Array.Copy(_marks, 0, copy, 0, _marks.Length);
                return copy; //откуда копируем,с какого индекса, куда копируем, с какого индекса вставляем в новый, сколько копируем(все)
            }
        }

        public int TotalScore
        {
            get
            {
                int total = 0;
                foreach (int value in _marks)//проходимся по каждому числу вэлью в массиве
                {
                    total += value;
                }
                return total;
            }
        }
        
        //конструктор что делает 
        public Participant(string name, string surname)
        {
            _name = name;
            _surname = surname;
            _marks = new int[2,5]; //столбцы и строки
        }

        public void Jump(int[] result)
        {
            if (result.Length != 5 || result == null || (_fjump && _sjump)) return;
            if (!_fjump)
            {
                for (int j = 0; j < _marks.GetLength(1); j++)
                {
                    _marks[0,j] = result[j];
                    _fjump = true;
                }
            }
            
            else if (!_sjump)
            {
                for (int j = 0; j < _marks.GetLength(1); j++)
                {
                    _marks[1,j] = result[j];
                    _sjump = true;
                }
            }
        }

        public static void Sort(Participant[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)//не трогаем отсортированный хвост 
                {
                    if (array[j].TotalScore < array[j + 1].TotalScore)
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }

        public void Print()
        {
            return;
        }
        
        
    }
    }
}
