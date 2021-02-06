using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace github_docker_auto_deploy_test.Controllers
{
    public class DataControllerRequest
    {
        public int NumberOne { get; set; }
        public int NumberTwo { get; set; }

        public DataControllerRequest(int numberOne, int numberTwo)
        {
            NumberOne = numberOne;
            NumberTwo = numberTwo;
        }
    }
}
