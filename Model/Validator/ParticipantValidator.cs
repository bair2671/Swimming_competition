namespace Model.Validator
{
    public class ParticipantValidator : IValidator<Participant>
    {
        public void Validate(Participant entity)
        {
            if (entity.GetNume() == null)
                throw new ValidationException("Numele nu poate fi vid!");
            if (entity.GetVarsta() < 1)
                throw new ValidationException("Varsta nu poate fi negativa sau nula!");
        }
    }
}
