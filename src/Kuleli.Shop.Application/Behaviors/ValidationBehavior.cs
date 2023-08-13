using ArxOne.MrAdvice.Advice;
using FluentValidation.Results;
using Kuleli.Shop.Application.Exceptions;

namespace Kuleli.Shop.Application.Behaviors
{
    public class ValidationBehavior : Attribute, IMethodAdvice
    {
        private readonly Type _validatorType;//CreateCategoryValidator

        public ValidationBehavior(Type validatorType)
        {
            _validatorType = validatorType;
        }
        public void Advise(MethodAdviceContext context)
        {
            // metod calısmadan once devreye girecek kodlar
            //Invoke: 

            if (context.Arguments.Any())
            {
                var requestModel = context.Arguments[0];//CreateCategoryViewModel

                //Request model dogrulamasi-FluentValidation
                var validateMethod = _validatorType.GetMethod("Validate", new Type[] { requestModel.GetType() });
                var validatorInstance = Activator.CreateInstance(_validatorType);

                if (validateMethod != null)
                {
                    var validationResult = (ValidationResult)validateMethod.Invoke(validatorInstance, new object[] { requestModel });
                    if (!validationResult.IsValid)
                    {
                        throw new ValidateException(validationResult);
                    }
                }
            }      
            
            context.Proceed();//Metod tetikleniyor

            //metod calistiktan sonra devreye girecek kodlar
        }

    }
}
