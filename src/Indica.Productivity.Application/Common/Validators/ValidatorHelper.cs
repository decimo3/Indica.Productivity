namespace Indica.Productivity.Application.Common.Validators
{
    public static class ValidationHelper
    {
        public static Dictionary<string, List<string>> ValidateObjectFields<T>(T obj, Dictionary<string, List<ValidatorModel>> rules)
        {
            var errors = new Dictionary<string, List<string>>();
            var type = typeof(T);

            foreach (var rule in rules)
            {
                var prop = type.GetProperty(rule.Key);
                if (prop == null) continue;

                var value = prop.GetValue(obj)?.ToString() ?? "";
                var fieldErrors = new List<string>();

                foreach (var validator in rule.Value)
                {
                    var error = validator.Validate(value);
                    if (error != null)
                        fieldErrors.Add(error);
                }

                if (fieldErrors.Count > 0)
                    errors[rule.Key] = fieldErrors;
            }
            return errors;
        }
    }
}
