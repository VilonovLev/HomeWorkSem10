
// Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
// так чтобы в одной группе все числа в группе друг на друга не делились? Найдите M при заданном N 
// и получите одно из разбиений на группы N ≤ 10²⁰.
// Например, для N = 50, M получается 6
Console.WriteLine("\nЗадача 73:");
decimal num = 100;
string[] arrayNum = new string[2];
arrayNum[0] = "1";
arrayNum[1] = "2";

for (long i = 3; i <= num; i++)
{
    bool record = false;
    for (long j = 0; j < arrayNum.Length; j++)
    {
        string[] tempArr = arrayNum[j].Split(new char[] { ' ' });
        for (long k = 0; k < tempArr.Length; k++)
        {
            decimal tempNum = Convert.ToDecimal(tempArr[k]);
            if (i % tempNum == 0)
            {
                break;
            }
            if (k == tempArr.Length - 1)
            {
                arrayNum[j] = arrayNum[j] + ' ' + i;
                record = true;
            }
        }
        if (record)
        {
            break;
        }
        if (j == arrayNum.Length - 1)
        {
            arrayNum = ExpandArray(arrayNum);
            arrayNum[arrayNum.Length - 1] = Convert.ToString(i);
            break;
        }
    }
}
Print(arrayNum);

//  Дополнительная задача 74*: 4 друга должны посетить 12 пабов, в котором выпить по британской пинте пенного напитка.
//  До каждого бара идти примерно 15-20 минут, каждый пьет пинту за 15 минут. 
//  У первого друга лимит выпитого 1.1 литра, у второго 1.5, у третьего 2.2 литра, у 4 - 3.3 литра, это их максимум. 
//  Необходимо выяснить, до скольки баров смогут дойти каждый из друзей(Пройденное расстояние (в барах)), 
//  пока не упадет. И сколько всего времени будет потрачено на выпивку.
Console.WriteLine("\nЗадача 74:");
double[] fourFriends = { 1.1, 1.5, 2.2, 3.3 };
int[] roadToBar = { 15, 21 };
partyTime(fourFriends, roadToBar);

//Методы

string[] ExpandArray(string[] str)
{
    string[] tempArr = new string[str.Length + 1];
    for (int i = 0; i < arrayNum.Length; i++)
    {
        tempArr[i] = str[i];
    }
    return arrayNum = tempArr;
}

void Print(string[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.WriteLine($"группа {i + 1}: {arr[i]}");
    }
}

void partyTime(double[] resistance, int[] mapBars)
{
    int onePint = 15;
    double pint = 0.56;
    for (int friend = 0; friend < resistance.Length; friend++)
    {
        int resultTime = 0;
        int barCount = 0;
        while (resistance[friend] > 0)
        {
            resultTime += onePint + new Random().Next(mapBars[0], mapBars[1]);
            resistance[friend] -= pint;
            barCount++;
        }
        Console.WriteLine($"{friend + 1}-й упадёт в {barCount} баре через {resultTime / 60}"
                            + $" часов {resultTime % 60} минут");
    }
}
