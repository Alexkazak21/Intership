#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    int x1, y1, x2, y2;
    cout << "Введите координаты первого слона (x1 y1): ";
    cin >> x1 >> y1;
    cout << "Введите координаты второго слона (x2 y2): ";
    cin >> x2 >> y2;

    if (abs(x1 - x2) == abs(y1 - y2))
    {
        cout << "Слоны бьют друг друга." << endl;
    }
    else
    {
        cout << "Слоны не бьют друг друга." << endl;
    }

    return 0;
}
