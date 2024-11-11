#include <iostream>
#include <cmath>
#include <algorithm>
#include <vector>

using namespace std;

void printDigits(int n)
{
    cout << "Цифры числа " << n << " по отдельности:" << endl;
    while (n > 0)
    {
        int digit = n % 10;
        cout << digit << endl;
        n /= 10;
    }
}

int sumOfDigits(int n)
{
    int sum = 0;
    while (n > 0)
    {
        sum += n % 10;
        n /= 10;
    }
    cout << "Сумма цифр числа: " << sum << endl;
    return sum;
}

int productOfDigits(int n)
{
    int product = 1;
    while (n > 0)
    {
        product *= n % 10;
        n /= 10;
    }
    cout << "Произведение цифр числа: " << product << endl;
    return product;
}

bool isIncreasingSequence(int n)
{
    bool isIncreasing = true;
    int previousDigit = 10;
    while (n > 0)
    {
        int currentDigit = n % 10;
        if (currentDigit >= previousDigit)
        {
            isIncreasing = false;
            break;
        }
        previousDigit = currentDigit;
        n /= 10;
    }
    cout << (isIncreasing ? "Число является возрастающей последовательностью цифр."
                          : "Число не является возрастающей последовательностью цифр.")
         << endl;
    return isIncreasing;
}

void printMinMidMaxDigit(int n)
{
    vector<int> digits;
    while (n > 0)
    {
        digits.push_back(n % 10);
        n /= 10;
    }
    sort(digits.begin(), digits.end());

    int minDigit = digits.front();
    int maxDigit = digits.back();
    int midDigit = digits[digits.size() / 2]; // средняя цифра в отсортированном массиве

    cout << "Минимальная цифра: " << minDigit << endl;
    cout << "Средняя цифра: " << midDigit << endl;
    cout << "Максимальная цифра: " << maxDigit << endl;
}

bool hasConsecutiveDuplicates(int n)
{
    int previousDigit = -1;
    bool hasDuplicates = false;
    while (n > 0)
    {
        int currentDigit = n % 10;
        if (currentDigit == previousDigit)
        {
            hasDuplicates = true;
            break;
        }
        previousDigit = currentDigit;
        n /= 10;
    }
    cout << (hasDuplicates ? "Число содержит две одинаковые цифры подряд."
                           : "Число не содержит две одинаковые цифры подряд.")
         << endl;
    return hasDuplicates;
}

int main()
{
    int n;
    cout << "Введите натуральное число: ";
    cin >> n;

    printDigits(n);              // Функция 1
    sumOfDigits(n);              // Функция 2
    productOfDigits(n);          // Функция 3
    isIncreasingSequence(n);     // Функция 4
    printMinMidMaxDigit(n);      // Функция 5
    hasConsecutiveDuplicates(n); // Функция 6

    return 0;
}
