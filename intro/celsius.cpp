#include <iostream>

using namespace std;

int main()
{
    double fdegrees, cdergees;
    cout << "FAhrenheit to CELSIUS CONVERSION" << endl
         << endl;
    cout << "Degrees Fahrengeit?\n";
    cin >> fdegrees;
    cdergees = ((fdegrees - 32.0) * 5.0) / 9.0;
    cout << "Degrees Celsius " << cdergees;
    return 0;
}