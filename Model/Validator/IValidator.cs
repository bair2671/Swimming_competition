namespace Model.Validator
{
    interface IValidator<E>
    {
        void Validate(E entity);
    }
}
