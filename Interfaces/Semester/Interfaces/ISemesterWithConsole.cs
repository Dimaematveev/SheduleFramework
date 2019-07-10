using Interface.Interface;
using Interface.Interfaces;
using DaysOfStudy.Interfaces;

namespace Semester.Interfaces
{
    public interface ISemesterWithConsole<T>  : ISemester<T>, IConsole
    where T: IDaysOfStudyWithConsole
    {
    }
}
