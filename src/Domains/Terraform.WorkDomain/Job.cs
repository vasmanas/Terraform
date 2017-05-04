using System;
using System.Collections.Generic;
using Terraform.CommonDomain;

namespace Terraform.WorkDomain
{
    public class Job : Aggregate
    {
        private List<Requirement> requirements = new List<Requirement>();

        public Job(string displayName)
        {
            this.DisplayName = displayName;
        }

        public string DisplayName { get; private set; }

        public IReadOnlyCollection<Requirement> Requirements
        {
            get
            {
                return this.requirements.AsReadOnly();
            }
        }

        public void AddRequirement(Requirement newRequirement)
        {
            if (newRequirement == null)
            {
                throw new ArgumentNullException(nameof(newRequirement));
            }

            this.requirements.Add(newRequirement);
        }
    }
}
