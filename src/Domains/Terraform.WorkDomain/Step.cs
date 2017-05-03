using System.Collections.Generic;

namespace Terraform.WorkDomain
{
    public class Step
    {
        private List<Requirement> requirements = new List<Requirement>();

        public Step()
        {
        }

        public IReadOnlyCollection<Requirement> Requirements
        {
            get
            {
                return this.requirements.AsReadOnly();
            }
        }
    }
}
