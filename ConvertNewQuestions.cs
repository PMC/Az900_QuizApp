namespace Az900_QuizApp;

using System;
using System.IO;

public class ConvertNewQuestions
{
    public static void Convert(string questionFile, string answerFile, int startAt)
    {
        ReadQuestions(questionFile, startAt);
        ReadAnswers(answerFile, startAt);
    }

    private static void ReadAnswers(string file, int questionIndex)
    {
        int questionId = questionIndex;
        try
        {
            // Open the file for reading using a StreamReader
            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                // Read and display lines from the file until the end is reached
                while ((line = reader.ReadLine()) != null)
                {
                    var answer = line.Substring(4, 1);
                    Console.WriteLine(
                        $"{{\"question_id\": {questionId++}, \"correct_option\": \"{answer}\"}},");
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File not found at {file}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
        }
    }


    private static void ReadQuestions(string questionFile, int questionIndex)
    {
        int questionId = questionIndex;
        try
        {
            // Open the file for reading using a StreamReader
            using (StreamReader reader = new StreamReader(questionFile))
            {
                string line;
                // Read and display lines from the file until the end is reached
                while ((line = reader.ReadLine()) != null)
                {
                    var question = line.Substring(4);
                    var validLine = reader.ReadLine();
                    var questionOption1 = validLine.Substring(3);
                    var questionOption2 = reader.ReadLine().Substring(3);
                    var questionOption3 = reader.ReadLine().Substring(3);
                    var questionOption4 = reader.ReadLine().Substring(3);
                    if (validLine.StartsWith("A") == false)
                    {
                        Console.WriteLine($"Error on question: \n{question}\nOption 1 did not start with an A");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine(
                        $"{{\n\"question_id\": {questionId++},\n\"question\": \"{question}\",\n\"options\": [\n\"{questionOption1}\",\n\"{questionOption2}\",\n\"{questionOption3}\",\n\"{questionOption4}\"\n]\n}},");
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File not found at {questionFile}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
        }
    }
}