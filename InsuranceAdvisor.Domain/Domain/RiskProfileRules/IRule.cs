using InsuranceAdvisor.Domain.Domain.Entities;

namespace InsuranceAdvisor.Domain.Domain.Rules
{
    internal interface IRule<in TTarget, out TResponse> where TTarget : class
                                                        where TResponse : class
    {


        TResponse Validate(TTarget target);
    }
}
