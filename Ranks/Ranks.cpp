#include <iostream>
#include <math.h>
#include <string>

using namespace std;

int Reverse(int number);

int main()
{
    int number = 0;

    cout << "Insert your number" << endl;
    cin >> number;

    int revercedNumber = 0;

    if (number < 0)
    {
        number = abs(number);
        revercedNumber = -Reverse(number);
    }
    else
    {
        revercedNumber = Reverse(number);
    }

    cout << "Reversed number is " << revercedNumber;
    return 0;
}

int Reverse(int number)
{
    int m = 0;

    while (number)
    {
        m = m * 10 + number % 10;
        number /= 10;
    }

    return m;
}