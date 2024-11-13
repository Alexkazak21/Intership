#include <iostream>
#include <string>
#include <bitset>

using namespace std;

bool IsRotation(int number);
double DecimalToBinary(int decimalNumber);

int main()
{
    int searchInt = 0;

    cout << "Insert your decimal number for check." << endl;
    cout << "Your decimal is: ";

    cin >> searchInt;

    cout << "Your number in decimal is: " << DecimalToBinary(searchInt) << endl;
    cout << (IsRotation(searchInt) ? "1 and 0 is rotate" : "1 and 0 isn`t rotate");

    return 0;
}

double DecimalToBinary(int decimalNumber)
{
    double binaryNumber = 0.0;
    double placeValue = 1.0;

    while (decimalNumber > 0)
    {
        double remainder = decimalNumber % 2;
        binaryNumber += remainder * placeValue;
        decimalNumber /= 2.0;
        placeValue *= 10.0;
    }

    return binaryNumber;
}

bool IsRotation(int number)
{
    int xorResult = number ^ (number >> 1);

    return (xorResult & (xorResult + 1)) == 0;
}