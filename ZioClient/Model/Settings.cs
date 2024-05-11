using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZioClient.Model.ModelData;

namespace ZioClient.Model
{
    public static class Settings
    {
        public static bool AreQuestionsReady { get; set; }
        public static List<QuestionProcess> QuestionsProcess { get; set; }
        public static string Nick { get; set; }
    }
}
