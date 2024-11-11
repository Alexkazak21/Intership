#include <iostream>

using namespace std;

void CountUp();
void CountDown();

int main()
{
    CountUp();
    CountDown();
    return 0;
}

void CountUp()
{
    int maxCount = 10;

    cout << "\n\nCounting up to " << maxCount;
    for (int i = 0; i <= maxCount; i++)
    {
        cout << i << " ";
    }
}

void CountDown()
{
    int maxCount = 10;

    cout << "\n\nCounting down from " << maxCount;
    for (int i = maxCount; i >= 0; i--)
    {
        cout << i << " ";
    }
}