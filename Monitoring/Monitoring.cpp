#include <iostream>
#include <vector>

using namespace std;

vector<int> FindInvisiablePoints(int profile[], int size)
{
    double maxAngele = -1e9;
    vector<int> invisPoints = {};

    for (int i = 1; i < size; i++)
    {
        double angle = (profile[i] - profile[0]) / (i * 1.0);
        if (angle >= maxAngele)
        {
            maxAngele = angle;
        }
        else
        {
            invisPoints.push_back(profile[i]);
        }
    }

    return invisPoints;
}

int main()
{

    int profile[] = {10, 8, 12, 15, 7, 16, 14};
    vector<int> invisiblePoints = {};

    size_t size = sizeof(profile) / sizeof(profile[0]);
    invisiblePoints = FindInvisiablePoints(profile, size);

    // cout << "Invisiable points: ";
    for (int index : invisiblePoints)
    {
        cout << index << " ";
    }
    cout << endl;
    return 0;
}