using System;
using System.IO;

string responseOne = "responsePlayerOne.txt";
string responseTwo = "responsePlayerSecond.txt";

string[] questionsOne = [
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
string[] questionsTwo = [
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

int[] answerOne = new int[first_questions.Length];
int[] answerTwo = new int[second_questions.Length];

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

string[] linesOne =  File.ReadAllLines("AnswerFirstPerson.txt");
string[] linesTwo =  File.ReadAllLines("AnswerSecondPerson.txt");

int scorePlayerOne = OnePersonPlay(linesOne, questionsOne, answerOne, responseOne);
int scorePlayerTwo = OnePersonPlay(linesTwo, questionsTwo, answerTwo, responseTwo);

if (scorePlayerOne>scorePlayerTwo){
    Console.WriteLine("Результы игры\nПобедил Игрок 1");
}
else if(scorePlayerOne<scorePlayerTwo){
    Console.WriteLine("Результы игры\nПобедил Игрок 2");
}
else{
    Console.WriteLine("Результы игры:\nНичья");
}