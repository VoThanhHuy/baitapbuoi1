using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int targetNumber = random.Next(100, 1000); // Số ngẫu nhiên từ 100 đến 999
        string target = targetNumber.ToString();

        Console.WriteLine("chao mung ban den voi tro choi doan so!");
        Console.WriteLine("may tinh da phat sinh mot so co 3 chu so tu 100 den 999.");
        Console.WriteLine("ban co 7 lan doan de tim ra so do.");

        int attempts = 0;
        bool won = false;

        while (attempts < 7 && !won)
        {
            Console.Write($"Lan doan thu {attempts + 1}: ");
            string guess = Console.ReadLine();

            if (guess.Length != 3 || !int.TryParse(guess, out int guessNumber) || guessNumber < 100 || guessNumber > 999)
            {
                Console.WriteLine("Vui long nhap 1 so co 3 chu so tu 100 den 999.");
                continue;
            }

            attempts++;

            if (guess == target)
            {
                won = true;
                break;
            }

            string feedback = GenerateFeedback(target, guess);
            Console.WriteLine($"Phan hoi: {feedback}");
        }

        if (won)
        {
            Console.WriteLine($"Chuc mung! Ban đa doan dung so {target} trong {attempts} lan doan.");
        }
        else
        {
            Console.WriteLine($"Rat tiec! Ban đa het 7 lan doan. So Dung la {target}.");
        }
    }

    static string GenerateFeedback(string target, string guess)
    {
        char[] feedback = new char[3];

        // Kiểm tra dấu '+'
        for (int i = 0; i < 3; i++)
        {
            if (guess[i] == target[i])
            {
                feedback[i] = '+';
            }
        }

        // Kiểm tra dấu '?'
        for (int i = 0; i < 3; i++)
        {
            if (feedback[i] != '+' && target.Contains(guess[i]))
            {
                for (int j = 0; j < 3; j++)
                {
                    if (guess[i] == target[j] && feedback[j] != '+')
                    {
                        feedback[j] = '?';
                        break;
                    }
                }
            }
        }

        return new string(feedback);
    }
}
