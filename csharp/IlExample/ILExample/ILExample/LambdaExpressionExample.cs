using System;

namespace ILExample
{
    class LambdaExpressionExample
    {
        public void Example()
        {
            ShowNumWithDelegate(1, num => num + 1);
            ShowNumWithDelegate(1, num => Multiple(num, 5));

            int addNum = 0;
            ShowNumWithDelegate(1, num => num + addNum);
        }

        int Multiple(int a, int b)
        {
            return a * b;
        }

        void ShowNumWithDelegate(int num, Func<int, int> func)
        {
            Console.WriteLine(func(num));
        }
    }
}
