namespace AoC_12
{
    internal class Program
    {
        static List<List<char>> board = new List<List<char>>();

        static void Main(string[] args)
        {
            int horizontalReflectionPoint = -1;
            int verticalReflectionPoint = -1;

            int count = 0;
            foreach (string line in File.ReadAllLines(@"C:\Games\12.txt"))
            {
                if (line.Length == 0)
                {
                    horizontalReflectionPoint = -1;
                    verticalReflectionPoint = -1;

                    for (int j = 1; j < board.Count; j++)
                    {
                        if (IsHorizontalReflectionPoint(j))
                        {
                            horizontalReflectionPoint = j;
                            count += 100 * horizontalReflectionPoint;
                            break;
                        }
                    }
                    if (horizontalReflectionPoint == -1)
                    {
                        for (int j = 1; j < board[0].Count; j++)
                        {
                            if (IsVerticalReflectionPoint(j))
                            {
                                verticalReflectionPoint = j;
                                count += verticalReflectionPoint;
                                break;
                            }
                        }
                    }
                    board = new List<List<char>>();
                }
                else
                {
                    board.Add(new List<char>(line.ToArray()));
                }

            }

            horizontalReflectionPoint = -1;
            verticalReflectionPoint = -1;

            for (int j = 1; j < board.Count; j++)
            {
                if (IsHorizontalReflectionPoint(j))
                {
                    horizontalReflectionPoint = j;
                    count += 100 * horizontalReflectionPoint;
                    break;
                }
            }
            if (horizontalReflectionPoint == -1)
            {
                for (int j = 1; j < board[0].Count; j++)
                {
                    if (IsVerticalReflectionPoint(j))
                    {
                        verticalReflectionPoint = j;
                        count += verticalReflectionPoint;
                        break;
                    }
                }
            }

            Console.WriteLine(count);
        }

        static bool IsHorizontalReflectionPoint(int p)
        {
            int r1 = p - 1;
            int r2 = p;

            int smudgeCount = 0;
            while (r1 >= 0 && r2 < board.Count)
            {
                for (int i = 0; i < board[0].Count; ++i)
                {
                    if (board[r1][i] != board[r2][i])
                    {
                        if (smudgeCount > 0)
                        {
                            return false;
                        }
                        else
                        {
                            // the one and only smudge!!
                            smudgeCount++;
                        }
                    }
                }
                r1--;
                r2++;
            }
            if (smudgeCount == 0)
            {
                return false;
            }
            return true;
        }

        static bool IsVerticalReflectionPoint(int p)
        {
            int r1 = p - 1;
            int r2 = p;

            int smudgeCount = 0;
            while (r1 >= 0 && r2 < board[0].Count)
            {
                for (int i = 0; i < board.Count; ++i)
                {
                    if (board[i][r1] != board[i][r2])
                    {
                        if (smudgeCount > 0)
                        {
                            return false;
                        }
                        else
                        {
                            // the one and only smudge!!
                            smudgeCount++;
                        }
                    }
                }
                r1--;
                r2++;
            }
            if (smudgeCount == 0)
            {
                return false;
            }
            return true;
        }
    }
}