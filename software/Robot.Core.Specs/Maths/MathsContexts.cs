using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using Robot.Core.Maths;
using developwithpassion.specifications.fakeiteasy;

namespace Robot.Core.Specs.Maths
{

    [Subject(typeof(Matrix4))]
    public class with_matrix4 : Observes<Matrix4>
    {
        Establish c = () => depends.on(new[,]
        {
            {1.0, 0.0, 0.0, 0.0},
            {0.0, 1.0, 0.0, 0.0},
            {0.0, 0.0, 1.0, 0.0},
            {0.0, 0.0, 0.0, 1.0}
        });
        protected static Matrix4 result;
    }

}
