using System.Collections.Generic;

namespace Terraform.Core.Messaging
{
    public class EnumerableRequest<TResult> : Request<IEnumerable<TResult>>
    {
    }
}
