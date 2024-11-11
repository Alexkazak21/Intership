#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    int x1, y1, x2, y2;
    cout << "Введите координаты первого коня (x1 y1): ";
    cin >> x1 >> y1;
    cout << "Введите координаты второго коня (x2 y2): ";
    cin >> x2 >> y2;

    int dx = abs(x1 - x2);
    int dy = abs(y1 - y2);

    if ((dx == 2 && dy == 1) || (dx == 1 && dy == 2))
    {
        cout << "Кони бьют друг друга." << endl;
    }
    else
    {
        cout << "Кони не бьют друг друга." << endl;
    }

    return 0;
}
