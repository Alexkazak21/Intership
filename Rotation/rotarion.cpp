#include <iostream>
#include <string>

using namespace std;

bool IsRotation(string str);

int main()
{
    string searchStr = "";
    bool isClear;

    cout << "Insert your binary number for check." << endl;
    cout << "Your binari is: ";

    cin >> searchStr;

    if (searchStr.length() < 2)
    {
        cout << "Number must be longer then 1 digit";
        return 1;
    }

    cout << (IsRotation(searchStr) ? "1 and 0 is rotate" : "1 and 0 isn`t rotate");

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