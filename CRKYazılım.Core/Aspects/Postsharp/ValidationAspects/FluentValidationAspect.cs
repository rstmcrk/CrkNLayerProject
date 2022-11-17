using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;
using FluentValidation;
using CRKYazılım.Core.CrossCuttingConcerns.Validation.FluentValidation;

namespace CRKYazılım.Core.Aspects.Postsharp.ValidationAspects
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        Type _ValidatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _ValidatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_ValidatorType);
            var entityType = _ValidatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
        }
    }
}
