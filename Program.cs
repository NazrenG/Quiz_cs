using System;
using System.Threading;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Menu(byte choose, string[,] arr, int questionNum, ref int point, string[] answers)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n\n\n\t\t\t\t~~~~~~~  Quiz  ~~~~~~~  \n\n");

            Console.Write($"\t\t\tPoint: ");
          Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(point);
            
            Console.WriteLine($"\n\t\t\t{questionNum + 1}. {arr[questionNum, 0]}");

            switch (choose)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\t\t\t=> A){arr[questionNum, 1]}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t\t\t B){arr[questionNum, 2]} ");
                    Console.WriteLine($"\t\t\t C){arr[questionNum, 3]} ");
                    Console.WriteLine($"\n\t\t\t Exit");

                    answers[questionNum] = arr[questionNum, 1];
                    break;
                case 2:

                    Console.WriteLine($"\t\t\t A){arr[questionNum, 1]}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\t\t\t=> B){arr[questionNum, 2]} ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t\t\t C){arr[questionNum, 3]} ");
                    Console.WriteLine($"\n\t\t\t Exit");

                    answers[questionNum] = arr[questionNum, 2];
                    break;
                case 3:

                    Console.WriteLine($"\t\t\t A){arr[questionNum, 1]}");
                    Console.WriteLine($"\t\t\t B){arr[questionNum, 2]} ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\t\t\t=> C){arr[questionNum, 3]} ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n\t\t\t Exit");

                    answers[questionNum] = arr[questionNum, 3];
                    break;
                case 4:

                    Console.WriteLine($"\t\t\t A){arr[questionNum, 1]}");
                    Console.WriteLine($"\t\t\t B){arr[questionNum, 2]} ");
                    Console.WriteLine($"\t\t\t C){arr[questionNum, 3]} ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n\t\t\t=> Exit");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

            }

        }

        static void checkAnswer(string[,] arr, int questionNum, ref int point, string[] answers)
        {
            if (arr[questionNum, 4] == answers[questionNum])
            {
                Console.ForegroundColor = ConsoleColor.Green;

                point += 10;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                point -= 10;
                if (point < 0) point = 0;
            }
        }
        //cavablari shuffle etmek
        static void shuffleAnswer(string[,] arr)
        {
            Random rand = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                string[] answer=new string[3];
                for (int j = 0; j < answer.Length; j++)
                {
                    answer[j] = arr[i, j + 1];
                }

                for (int j = answer.Length-1; j >0; j--)
                {
                    int index = rand.Next(answer.Length);
                    string temp = answer[j];
                    answer[j] = answer[index];
                    answer[index] = temp;
                }

                for (int j = 0; j < answer.Length; j++)
                {
                    arr[i, j + 1] = answer[j];
                }
            }
        }
     

        static void Main(string[] args)
        {
            
            string[,] questions = { 
                { "Hansi ifade riyaziyyatda termin kimi istifade oluna biler? ", "tale", "bext", "qismet", "qismet" }, 
                { "(20-15)*3+2*7.5=? ", "20", "30", "35", "30" }, 
                { "Tam sakitliye riayet olunan mekan? ", "kitabxana", "stadion", "bazar", "kitabxana" }, 
                { "Kanadanin bayraginda hansi agacin yarpagi tesvir olunub? ", "fistiq", "agcaqayin", "palid", "agcaqayin" } ,
                { "Qiz qalasinin hundurluyu ne qederdir? ", "24", "26", "28", "28" } ,
                { "Ilin en qisa gecesi hansi fesile tesaduf edir? ", "yay", "qis", "yaz", "yay" } ,
                { "Kimyada tesirsiz qazlar nece adlanir?", "agilli", "necib", "intellektual", "necib" } ,
                { "Azerbaycan elifbasinda nece herf var? ", "28", "32", "33", "32" } ,
                { "Su saatinin diger adi nedir? ", "akveduk", "hidrobiont", "klepsidra", "klepsidra" } ,
                { "Ucbucagin daxili bucaqlarinin cemi? ", "360", "90", "180", "180" } ,
            };

            shuffleAnswer(questions);

            string[] userAnswer = new string[questions.GetLength(0)];
            dynamic select;
            byte choose = 1, questionNum = 0;
            int point = 0;
            bool check = true;
            Menu(choose, questions, questionNum, ref point, userAnswer);


            while (check)
            {
                select = Console.ReadKey();
                if (select.Key == ConsoleKey.UpArrow)
                {
                    if (choose == 1) choose = 4;
                    else choose--;
                    Menu(choose, questions, questionNum, ref point, userAnswer);
                }
                else if (select.Key == ConsoleKey.DownArrow)
                {
                    if (choose == 4) choose = 1;
                    else choose++;
                    Menu(choose, questions, questionNum, ref point, userAnswer);
                }
                else if (select.Key == ConsoleKey.Enter)
                {
                    Thread.Sleep(1100);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\n\n\n\n\t\t\t\t~~~~~~~  Quiz  ~~~~~~~  \n\n");

                    Console.WriteLine($"\t\t\tPoint: {point}\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t\t\t{questionNum + 1}. {questions[questionNum, 0]}");

                    if (choose == 4)//exit secerse
                    {
                        Console.WriteLine("\t\t\t---------------------------------");
                        Console.Write("\n\t\t\t Quiz was stopped.Your total point is ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(point);
                        Console.ForegroundColor = ConsoleColor.White;
                        check = false;
                        break;
                    }

                    if (choose == 1)// A-ni secerse
                    {
                        checkAnswer(questions, questionNum, ref point, userAnswer);
                        Console.WriteLine($"\t\t\t=> A){questions[questionNum, 1]}");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\t\t\t B){questions[questionNum, 2]} ");
                        Console.WriteLine($"\t\t\t C){questions[questionNum, 3]} ");
                    }
                    else if (choose == 2)// B-ni secerse
                    {
                        Console.WriteLine($"\t\t\t A){questions[questionNum, 1]}");
                        checkAnswer(questions, questionNum, ref point, userAnswer);
                        Console.WriteLine($"\t\t\t=> B){questions[questionNum, 2]} ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\t\t\t C){questions[questionNum, 3]} ");

                    }
                    else if (choose == 3)// C-ni secerse
                    {
                        Console.WriteLine($"\t\t\t A){questions[questionNum, 1]}");
                        Console.WriteLine($"\t\t\t B){questions[questionNum, 2]} ");
                        checkAnswer(questions, questionNum, ref point, userAnswer);
                        Console.WriteLine($"\t\t\t=> C){questions[questionNum, 3]} ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    questionNum++;
                    Console.WriteLine($"\n\t\t\t Exit");

                    //quiz sona catarsa
                    if (questionNum == questions.GetLength(0))
                    {
                        Console.WriteLine("\t\t\t---------------------------------");
                        Console.WriteLine("\t\t\t\nCongrulate!!\n\t Quiz was finished.Your total point is ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(point);
                        Console.ForegroundColor = ConsoleColor.White;
                        check = false;
                        break;
                    }
                    Thread.Sleep(1000);
                    Menu(choose, questions, questionNum, ref point, userAnswer);

                }
            }

        }
    }
}
