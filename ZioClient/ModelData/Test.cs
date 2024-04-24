using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZioClient.ModelData
{
    public class Test
    {
        public int id { get; set; }
        public string nick { get; set; }
        public DateTime date { get; set; }
        public int result { get; set; }
        public List<TestQuestion> testQuestions { get; set; } = null;
    }
}
