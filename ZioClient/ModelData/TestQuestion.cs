using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZioClient.ModelData
{
    public class TestQuestion
    {
        public int? testId { get; set; }
        public Test test { get; set; }
        public int? questionId { get; set; }
        public Question question { get; set; }
    }
}
