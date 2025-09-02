using System;
using System.IO;

string first_response = "responsePlayerOne.txt";
string second_response = "responsePlayerSecond.txt";

string[] first_questions = [
    "Сколько лет Мише? ",
    "Сколько лет Маше? ",
    "Сколько лет Даше? ",
    "Сколько лет Глаше? ",
    "Сколько лет Диме? ",
    "Сколько лет Анатолию? ",
    "Сколько лет Тимуру? ",
    "Сколько лет Тане? ",
    "Сколько лет Кате? ",
    "Сколько лет Ане? "
];
string[] second_questions = [
    "Сколько глаз у Миши? ",
    "Сколько глаз у Маши? ",
    "Сколько глаз у Даши? ",
    "Сколько глаз у Глаши? ",
    "Сколько глаз у Димы? ",
    "Сколько глаз у Анатолия? ",
    "Сколько глаз у Тимура? ",
    "Сколько глаз у Тани? ",
    "Сколько глаз у Кати? ",
    "Сколько глаз у Ани? "
];

int[] first_answer = new int[first_questions.Length];
int[] second_answer = new int[second_questions.Length];

int OnePersonPlay(string[] lines, string[] questions, int[] list_answer, string response){
    int scoresPlayer = 0;

    for (int i=0; i<questions.Length; i++){
        int correctAnswersPlayer = int.Parse(lines[i]);

        Console.Write(questions[i]);
        int answer = int.Parse(Console.ReadLine());
        list_answer[i] = answer;
        File.AppendAllText(response, answer + "\n");

        if (answer == correctAnswersPlayer){
            scoresPlayer++;
        }
    }

    Console.WriteLine($"Игрок 1 набрал {scoresPlayer} из 10 баллов");

    return scoresPlayer;
}

string[] first_lines =  File.ReadAllLines("AnswerFirstPerson.txt");
string[] second_lines =  File.ReadAllLines("AnswerSecondPerson.txt");

int scorePlayerOne = OnePersonPlay(first_lines, first_questions, first_answer, first_response);
int scorePlayerTwo = OnePersonPlay(second_lines, second_questions, second_answer, second_response);

if (scorePlayerOne>scorePlayerTwo){
    Console.WriteLine("Результы игры\nПобедил Игрок 1");
}
else if(scorePlayerOne<scorePlayerTwo){
    Console.WriteLine("Результы игры\nПобедил Игрок 2");
}
else{
    Console.WriteLine("Результы игры:\nНичья");
}