#include <iostream>
#include <string>
#include <bitset>

using namespace std;

bool IsRotation(string str);

int main()
{
    int searchStr = 0;

    cout << "Insert your decimal number for check." << endl;
    cout << "Your decimal is: ";

    cin >> searchStr;

    string binary = bitset<8>(searchStr).to_string();
    binary.erase(0, binary.find_first_not_of('0'));

    if (binary.length() < 2)
    {
        cout << "Number must be longer then 1 digit";
        return 1;
    }

    cout << (IsRotation(binary) ? "1 and 0 is rotate" : "1 and 0 isn`t rotate");

    return 0;
}

bool IsRotation(string str)
{
    for (int i = 0; i < str.length() - 1; i++)
    {
        char currentChar = str[i];
        char nextChar = str[i + 1];

        if (currentChar == nextChar)
        {
            return false;
        }
    }

    return true;
}