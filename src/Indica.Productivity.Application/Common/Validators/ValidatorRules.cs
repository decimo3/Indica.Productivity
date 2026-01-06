namespace Indica.System.Application.Common.Validators
{
    public static class ValidatorRules
    {
        public static readonly ValidatorModel RegistryValidator = new (@"^[0-9]{7}$", "Matrícula inserida não é válida!");
        public static readonly ValidatorModel FullNameValidator = new (@"^([A-z\s]{2,}){2,}([A-z]{4,}){1}$", "Nome inserido não é válido!");
        public static readonly ValidatorModel PasswordValidator = new (@"^(?=.*[A-Z])(?=.*[!@#$&*])(?=.*[0-9])(?=.*[a-z]).{8,}$", "Senha deve conter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas, números e símbolos especiais!");
        public static readonly ValidatorModel PlateLicenceValidator = new (@"^[A-z0-9]{3}-[A-z0-9]{4}$", "A placa inserida não é válida!");
        public static readonly ValidatorModel OrderNumberValidator = new (@"^[0-9]{5}$", "O número de ordem inserido não é válido!");
        public static readonly ValidatorModel CellphoneValidator = new (@"^[0-9]{11}$", "O número de celular inserido não é válido!");
        public static readonly ValidatorModel ResourceValidator = new (@"^([A-Z]{3,})(?: - [A-z]{3,})?( [-|–] Equipe )([0-9]{3})$", "O recurso inserido não é válido!");
    }
}
