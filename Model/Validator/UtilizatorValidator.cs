namespace Model.Validator
{
    public class UtilizatorValidator : IValidator<Utilizator>
    {
        public void Validate(Utilizator entity)
        {
            if (entity.GetNume() == null)
                throw new ValidationException("Numele nu poate fi vid!");
            if (entity.GetPrenume() == null)
                throw new ValidationException("Prenumele nu poate fi vid!");
            if (entity.GetPassword() == null)
                throw new ValidationException("Parola nu poate fi vida!");
            if (entity.GetPassword().Length < 3)
                throw new ValidationException("Parola nu poate avea mai putin de 3 caractere!");
            if (entity.GetUsername() == null)
                throw new ValidationException("Username-ul nu poate fi vid!");
            if (entity.GetUsername().Length < 3)
                throw new ValidationException("Username-ul nu poate avea mai putin de 3 caractere!");
        }
    }
}
