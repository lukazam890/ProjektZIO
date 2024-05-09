using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZioClient.Model.ModelData;
using ZioClient.ModelData;

namespace ZioClient.WindowManagment.Interfaces
{
    public interface IMainWindowManager
    {
        List<QuestionProcess> getQuestions(int numberOfQuestions);
        string testResult(List<QuestionProcess> questionProcesses);
    }
}
