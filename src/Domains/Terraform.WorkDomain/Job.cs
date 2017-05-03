using System.Collections.Generic;

namespace Terraform.WorkDomain
{
    public class Job
    {
        private List<Step> steps = new List<Step>();

        public Job()
        {
        }

        public IReadOnlyCollection<Step> Steps
        {
            get
            {
                return this.steps.AsReadOnly();
            }
        }
    }
}
