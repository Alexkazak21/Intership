#include <iostream>
#include <math.h>

using namespace std;

int main()
{
    int binNumber = 0;
    cout << "Insert number in BINARY" << endl;
    cin >> binNumber;

    int decNumber = 0;

    int counter = 0;
    while (binNumber > 0)
    {
        int currDigit = binNumber % 10;

        if (currDigit == 1)
        {
            decNumber += pow(2.0, counter);
        }

        binNumber /= 10;
        counter++;
    }

    cout << "Decimal number is " << decNumber;
    return 0;
}