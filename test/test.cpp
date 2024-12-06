//  в целом числе распечатать среднюю и уникальную цифру
#include <math.h>
#include <iostream>

using namespace std;

int main()
{
    int number = 0;
    int maxDigit = -1;
    int minDigit = 9;

    int counter = 0;
    int totalSum = 0;

    cin >> number;

    while (number / 10 > 0)
    {
        counter++;
        int curDigit = number % 10;
        if (curDigit > maxDigit)
        {
            maxDigit = curDigit;
        }
        if (curDigit < minDigit)
        {
            minDigit = curDigit;
        }

        totalSum += number % 10;
        number /= 10;
    }

    if ((totalSum / counter) - minDigit > maxDigit - (totalSum / counter))
    {
        cout << minDigit;
    }

    cout << totalSum / counter << endl;
    cout << maxDigit << endl;
    return 0;
}