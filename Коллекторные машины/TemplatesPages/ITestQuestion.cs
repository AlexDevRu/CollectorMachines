using System;
using System.Windows.Controls;

namespace Коллекторные_машины
{
    public interface ITestQuestion
    {
        void Anew();
        void AddShowResult(Action<bool> ShowResult);
    }
}