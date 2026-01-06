using System.Text.RegularExpressions;

namespace Indica.Productivity.Application.Common.Validators
{
    public class ValidatorModel
    {
        private readonly Regex _regex;
        private readonly string _message;

        public ValidatorModel(string pattern, string message)
        {
            _regex = new Regex(pattern);
            _message = message;
        }

        public string? Validate(string value)
        {
            return _regex.IsMatch(value) ? null : _message;
        }
    }
}
